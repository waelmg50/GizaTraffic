using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Utilities;

public class AppSettingsService
{
    private readonly string _filePath;

    public AppSettingsService()
    {
        _filePath = Path.Combine(AppContext.BaseDirectory, "appsettings.json");
    }

    public string FilePath => _filePath;

    public bool Exists()
    {
        return File.Exists(_filePath);
    }

    public string? GetEncryptedConnectionString()
    {
        JsonNode root = LoadJson();
        return root["ConnectionStrings"]?["DBConnection"]?.GetValue<string>();
    }

    public string? GetConnectionString()
    {
        string? value = GetEncryptedConnectionString();
        if (string.IsNullOrWhiteSpace(value))
            return null;

        if (!ConnectionStringProtector.IsEncrypted(value))
            return null;

        return ConnectionStringProtector.Unprotect(value);
    }

    public bool IsDatabaseConfigured()
    {
        string? value = GetEncryptedConnectionString();

        if (string.IsNullOrWhiteSpace(value))
            return false;

        return ConnectionStringProtector.IsEncrypted(value);
    }

    public void SaveConnectionString(string connectionString)
    {
        if (string.IsNullOrWhiteSpace(connectionString))
            throw new ArgumentException("Connection string cannot be empty.", nameof(connectionString));
        JsonNode root;
        if (File.Exists(_filePath))
        {
            root = LoadJson();
        }
        else
        {
            root = new JsonObject();
        }
        JsonObject connectionStrings;
        if (root["ConnectionStrings"] is JsonObject existing)
        {
            connectionStrings = existing;
        }
        else
        {
            connectionStrings = [];
            root["ConnectionStrings"] = connectionStrings;
        }
        string encrypted = ConnectionStringProtector.Protect(connectionString);
        connectionStrings["DBConnection"] = encrypted;
        SaveJson(root);
    }

    private JsonNode LoadJson()
    {
        if (!File.Exists(_filePath))
        {
            throw new FileNotFoundException("appsettings.json was not found.", _filePath);
        }
        string json = File.ReadAllText(_filePath);
        if (string.IsNullOrWhiteSpace(json))
        {
            throw new InvalidOperationException("appsettings.json is empty.");
        }
        JsonNode? root = JsonNode.Parse(json);
        if (root == null)
        {
            throw new InvalidOperationException("appsettings.json contains invalid JSON.");
        }
        return root;
    }

    private void SaveJson(JsonNode root)
    {
        string backupPath = _filePath + ".backup";

        // Create a backup before changing the file.
        if (File.Exists(_filePath) && !File.Exists(backupPath))
        {
            File.Copy(_filePath, backupPath);
        }
        string json = root.ToJsonString(new JsonSerializerOptions
                {
                    WriteIndented = true
                });

        File.WriteAllText(_filePath, json, new UTF8Encoding(false));
    }
}
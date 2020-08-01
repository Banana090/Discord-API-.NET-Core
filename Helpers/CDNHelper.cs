using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordAPI.Helpers
{
    internal static class CDNHelper
    {
        internal static string cdn_enpoint = "https://cdn.discordapp.com/";

        internal static string GetEmojiUrl(string emoji_id) => $"{cdn_enpoint}emojis/{emoji_id}.png";
        internal static string GetGuildIconUrl(string guild_id, string hash) => $"{cdn_enpoint}icons/{guild_id}/{hash}.png";       
        internal static string GetGuildSplashUrl(string guild_id, string hash) => $"{cdn_enpoint}splashes/{guild_id}/{hash}.png";
        internal static string GetGuildDiscoverySplashUrl(string guild_id, string hash) => $"{cdn_enpoint}discovery-splashes/{guild_id}/{hash}.png";
        internal static string GetGuildBannerUrl(string guild_id, string hash) => $"{cdn_enpoint}banners/{guild_id}/{hash}.png";
        internal static string GetUserAvatarUrl(string user_id, string hash) => $"{cdn_enpoint}avatars/{user_id}/{hash}.png";      
        internal static string GetApplicationIconUrl(string application_id, string hash) => $"{cdn_enpoint}app-icons/{application_id}/{hash}.png";
        internal static string GetApplicationAssetUrl(string application_id, string hash) => $"{cdn_enpoint}app-assets/{application_id}/{hash}.png";      
        internal static string GetAchievementIconUrl(string application_id, string achievement_id, string hash) => $"{cdn_enpoint}app-assets/{application_id}/achievements/{achievement_id}/icons/{hash}.png";
        internal static string GetTeamIconUrl(string team_id, string hash) => $"{cdn_enpoint}team-icons/{team_id}/{hash}.png";
        internal static string GetDefaultUserAvatarUrl(string discriminator)
        {
            int i = 0;
            try
            {
                i = Convert.ToInt32(discriminator);
            }
            catch
            {
                Console.WriteLine($"Failed to get Default Avatar Url. Error: > {discriminator} < string is wrong");
            }
            i %= 5;
            return $"{cdn_enpoint}embed/avatars/{i}.png";
        }

    }
}

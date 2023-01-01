using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace XivMate.DataGathering.ACTLogs.Forms;

public class LogFileParser
{
    //Just zones we care about
    //Why Kugane and Gangos? Because would like to capture the lootbox drop tables and there's entities available here
    private static readonly string[] ZonesWeCareAbout = { "eureka", "southern front", "zadnor","kugane","gangos"};

    //
    private readonly List<XivChatType> ChatsCareAbout = new()
    {
        XivChatType.Debug, XivChatType.Echo, XivChatType.GatheringSystemMessage, XivChatType.None,
        XivChatType.Notice, XivChatType.SystemError, XivChatType.SystemMessage, XivChatType.Urgent
    };

    public bool IsZoneChange(string text)
    {
        return text.StartsWith("01") || text.StartsWith("40");
    }

    public bool ShouldStartRecording(string text)
    {
        return (IsZoneChange(text) && IsZoneWeCareAbout(text)) || (text.StartsWith("2") && text.IndexOf('|') == 3);
    }

    public bool IsZoneWeCareAbout(string text)
    {
        return ZonesWeCareAbout.Any(zone => text.ToLower().Contains(zone));
    }

    public string FilterLogLine(string text)
    {
        try
        {
            var code = int.Parse(text.Substring(0, text.IndexOf('|')));
            switch (code)
            {
                //Chat log, filter out personal chats
                case 0:
                    var chatCode = text.Split('|')[2];
                    return IsIgnoreChat(chatCode) ? null : text;
                default:
                    return text;
            }
        }
        catch (Exception e)
        {
            //If we couldn't tell the type of log, do NOT log
            return null;
        }
    }

    private bool IsIgnoreChat(string chatCode)
    {
        //Chat types only contain normal ones we care about, if we can't detect it, it **should** be find to output
        if (!int.TryParse(chatCode, NumberStyles.HexNumber, CultureInfo.CurrentCulture, out var intChatCode))
            return false;

        //Codes which aren't in the XivChatType are lengthy things like "X took critical hit!", which, I don't want to rule out for now
        if (!Enum.TryParse(intChatCode.ToString(), true, out XivChatType resultType))
            return false;

        return !ChatsCareAbout.Contains(resultType);
    }
}
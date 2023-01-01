namespace XivMate.DataGatheering.ACTLogs.Forms;

/// <summary>
///     The FFXIV chat types as seen in the LogKind ex table.
///     Stolen from: https://raw.githubusercontent.com/goatcorp/Dalamud/master/Dalamud/Game/Text/XivChatType.cs
/// </summary>
public enum XivChatType : ushort // FIXME: this is a single byte
{
    /// <summary>
    ///     No chat type.
    /// </summary>
    None = 0,

    /// <summary>
    ///     The debug chat type.
    /// </summary>
    Debug = 1,

    /// <summary>
    ///     The urgent chat type.
    /// </summary>
    Urgent = 2,

    /// <summary>
    ///     The notice chat type.
    /// </summary>
    Notice = 3,

    /// <summary>
    ///     The say chat type.
    /// </summary>
    Say = 10,

    /// <summary>
    ///     The shout chat type.
    /// </summary>
    Shout = 11,

    /// <summary>
    ///     The outgoing tell chat type.
    /// </summary>
    TellOutgoing = 12,

    /// <summary>
    ///     The incoming tell chat type.
    /// </summary>
    TellIncoming = 13,

    /// <summary>
    ///     The party chat type.
    /// </summary>
    Party = 14,

    /// <summary>
    ///     The alliance chat type.
    /// </summary>
    Alliance = 15,

    /// <summary>
    ///     The linkshell 1 chat type.
    /// </summary>
    Ls1 = 16,

    /// <summary>
    ///     The linkshell 2 chat type.
    /// </summary>
    Ls2 = 17,

    /// <summary>
    ///     The linkshell 3 chat type.
    /// </summary>
    Ls3 = 18,

    /// <summary>
    ///     The linkshell 4 chat type.
    /// </summary>
    Ls4 = 19,

    /// <summary>
    ///     The linkshell 5 chat type.
    /// </summary>
    Ls5 = 20,

    /// <summary>
    ///     The linkshell 6 chat type.
    /// </summary>
    Ls6 = 21,

    /// <summary>
    ///     The linkshell 7 chat type.
    /// </summary>
    Ls7 = 22,

    /// <summary>
    ///     The linkshell 8 chat type.
    /// </summary>
    Ls8 = 23,

    /// <summary>
    ///     The free company chat type.
    /// </summary>
    FreeCompany = 24,

    /// <summary>
    ///     The novice network chat type.
    /// </summary>
    NoviceNetwork = 27,

    /// <summary>
    ///     The custom emotes chat type.
    /// </summary>
    CustomEmote = 28,

    /// <summary>
    ///     The standard emotes chat type.
    /// </summary>
    StandardEmote = 29,

    /// <summary>
    ///     The yell chat type.
    /// </summary>
    Yell = 30,

    /// <summary>
    ///     The cross-world party chat type.
    /// </summary>
    CrossParty = 32,

    /// <summary>
    ///     The PvP team chat type.
    /// </summary>
    PvPTeam = 36,

    /// <summary>
    ///     The cross-world linkshell chat type.
    /// </summary>
    CrossLinkShell1 = 37,

    /// <summary>
    ///     The echo chat type.
    /// </summary>
    Echo = 56,

    /// <summary>
    ///     The system error chat type.
    /// </summary>
    SystemError = 58,

    /// <summary>
    ///     The system message chat type.
    /// </summary>
    SystemMessage = 57,

    /// <summary>
    ///     The system message (gathering) chat type.
    /// </summary>
    GatheringSystemMessage = 59,

    /// <summary>
    ///     The error message chat type.
    /// </summary>
    ErrorMessage = 60,

    /// <summary>
    ///     The NPC Dialogue chat type.
    /// </summary>
    NPCDialogue = 61,

    /// <summary>
    ///     The NPC Dialogue (Announcements) chat type.
    /// </summary>
    NPCDialogueAnnouncements = 68,

    /// <summary>
    ///     The retainer sale chat type.
    /// </summary>
    /// <remarks>
    ///     This might be used for other purposes.
    /// </remarks>
    RetainerSale = 71,

    /// <summary>
    ///     The cross-world linkshell 2 chat type.
    /// </summary>
    CrossLinkShell2 = 101,

    /// <summary>
    ///     The cross-world linkshell 3 chat type.
    /// </summary>
    CrossLinkShell3 = 102,

    /// <summary>
    ///     The cross-world linkshell 4 chat type.
    /// </summary>
    CrossLinkShell4 = 103,

    /// <summary>
    ///     The cross-world linkshell 5 chat type.
    /// </summary>
    CrossLinkShell5 = 104,

    /// <summary>
    ///     The cross-world linkshell 6 chat type.
    /// </summary>
    CrossLinkShell6 = 105,

    /// <summary>
    ///     The cross-world linkshell 7 chat type.
    /// </summary>
    CrossLinkShell7 = 106,

    /// <summary>
    ///     The cross-world linkshell 8 chat type.
    /// </summary>
    CrossLinkShell8 = 107
}
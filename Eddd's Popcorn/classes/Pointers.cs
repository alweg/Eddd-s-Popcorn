namespace SuperEd
{
    public static class Pointers
    {
        public static readonly string executableName =          "MaiD3Dvr";
        public static readonly string pTitleScreenCheck =       "MaiD3Dvr.exe+0x00300065";
        /*  pTitleScreenCheck values:

            "" | "bkmenu.bmp" | "ft.bmp" | ".bmp" || "\\0" 
        */

        public static readonly string pLevelName =              "MaiD3Dvr.exe+0x001BCA21";
        public static readonly string pSaveGameName =           "MaiD3Dvr.exe+0x001F80A8";
        public static readonly string pBackground =             "MaiD3Dvr.exe+0x002B9CC4,0x44,0xB4,0x30,0x4C,0x88,0x00";
        /*  pBackground values:

            "Menu\BkMenu.bmp"         | "Menu\Special\Plus.bmp" | "Logo2.bmp"             | "UbiSoft.bmp"               | Inventor\Inventaire_fond.bmp"
            "Level\Ski.bmp"           | "Level\Sud.bmp"         | "Level\CaveDoc.bmp"     | "Level\Carota.bmp"          | Level\North.bmp" 
            "Level\lecanyon.bmp"      | "Level\Cock.bmp"        | "Level\Marmite.bmp"     | "Level\Pyramide.bmp"        | Level\Land.bmp"
            "Credits\Credit01.bmp"    | "Credits\Credit02.bmp"  | "Credits\Credit03.bmp"  | "Credits\Credit04.bmp"      | Credits\Credit05.bmp"
            "Credits\Credit06.bmp"
        */

        public static readonly string pSprings =                    "MaiD3Dvr.exe+0x00179A8C,0x04,0x2C,0x38,0xBC,0x39C";
        public static readonly string pPinwheels =                  "MaiD3Dvr.exe+0x00179A5C,0x20,0x68,0x1C,0x04,0x51C";
        public static readonly string pJumpingStones =              "MaiD3Dvr.exe+0x00179A5C,0x20,0x68,0x1C,0x04,0x580";
        public static readonly string pFeathers =                   "MaiD3Dvr.exe+0x00179A98,0x18,0x20,0x94,0xBC,0x134";
        public static readonly string pDominoes =                   "MaiD3Dvr.exe+0x00179A84,0x0C,0x38,0xD4,0x04,0x66C";
        public static readonly string pPiggyBanks =                 "MaiD3Dvr.exe+0x00179A84,0x08,0x0C,0x04,0x00,0x69C";

        public static readonly string pPosX =                       "MaiD3Dvr.exe+0x002C5280,0x774,0x94,0x654,0xAC,0x9C";
        public static readonly string pPosY =                       "MaiD3Dvr.exe+0x002C5280,0x774,0x94,0x64C,0xBC,0xA4";
        public static readonly string pPosZ =                       "MaiD3Dvr.exe+0x001F81CC,0x4C,0x1CC,0x55C,0x1D8,0x22C";

        public static readonly string pRedspadesCurrent =           "MaiD3Dvr.exe+0x002B4EE0,0x28,0x38,0x18,0x174,0x34";
        public static readonly string pRedspadesMax =               "MaiD3Dvr.exe+0x002B4EE0,0x28,0x28,0x38,0x15";

        public static readonly string pSilverspadesText =           "MaiD3Dvr.exe+0x001BF270,0x24,0xB8,0x04,0x210";
        public static readonly string pSilverspadesTotalski =       "MaiD3Dvr.exe+0x00179800,0x30,0x00,0x08,0x70,0x208";
        public static readonly string pSilverspadesSud0 =           "MaiD3Dvr.exe+0x00179AA0,0x04,0x5C,0x14,0x44,0x250";
        public static readonly string pSilverspadesCavedoc =        "MaiD3Dvr.exe+0x00179AA0,0x04,0x00,0x04,0x44,0x250";
        public static readonly string pSilverspadesCarota =         "MaiD3Dvr.exe+0x002B4EC8,0x10,0x04,0x58,0x64,0x00";
        public static readonly string pSilverspadesNorth =          "MaiD3Dvr.exe+0x001797FC,0x24,0x00,0x00,0x00,0x7F0";
        public static readonly string pSilverspadesLecanyon =       "MaiD3Dvr.exe+0x00179800,0x04,0x10,0x0C,0x00,0x5A8";
        public static readonly string pSilverspadesCock01 =         "MaiD3Dvr.exe+0x00179AA0,0x04,0x0C,0x00,0x00,0x238";
        public static readonly string pSilverspadesPyramide =       "MaiD3Dvr.exe+0x001BF264,0x14,0x04,0x44,0x548";
        public static readonly string pSilverspadesMarmite =        "MaiD3Dvr.exe+0x001BF258,0x60,0x08,0x00,0x44,0x250";

        public static readonly string pWeapon1 =                    "MaiD3Dvr.exe+0x00179A50";
        public static readonly string pWeapon2 =                    "MaiD3Dvr.exe+0x00179A51";

        public static readonly string pStickInventoryIcon =         "MaiD3Dvr.exe+0x002C5280,0x00,0x04,0x0C,0x308";
        public static readonly string pBowtieInventoryIcon =        "MaiD3Dvr.exe+0x001BF278,0x38,0xC4,0x38,0xBC,0x312";
        public static readonly string pDivinghelmetInventoryIcon =  "MaiD3Dvr.exe+0x00179A7C,0x1C,0x08,0x0C,0x04,0x38E";
        public static readonly string pChameleonbeltInventoryIcon = "MaiD3Dvr.exe+0x000179A5C,0x1C,0x1C,0x04,0x3E6";

        public static readonly string pStickAttack =                "MaiD3Dvr.exe+0x000179A5C,0x1C,0x14,0x1C,0x04,0x9A";
        public static readonly string pStickMechanism =             "MaiD3Dvr.exe+0x000179A5C,0x1C,0x1C,0x04,0xF2";
        public static readonly string pStickMoveStoneL =            "MaiD3Dvr.exe+0x000179A6C,0x20,0x68,0x1C,0x04,0x14A";
        public static readonly string pStickBlowpipe =              "MaiD3Dvr.exe+0x000179A5C,0x1C,0x1C,0x08,0x04,0x17E";
        public static readonly string pStickPogo =                  "MaiD3Dvr.exe+0x000179A6C,0x08,0x1C,0x20,0x60,0x252";
        public static readonly string pStickPogoAttack =            "MaiD3Dvr.exe+0x00179A70,0x38,0xBC,0x54,0x04,0x136";
        public static readonly string pStickMoveStoneH =            "MaiD3Dvr.exe+0x000179A5C,0x1C,0x14,0x1C,0x04,0x1FA";

        public static readonly string pInvincible =                 "0x0041C358";
        public static readonly string pModefly =                    "MaiD3Dvr.exe+0x001BC8D4";
        
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using XivMate.DataGathering.ACTLogs.Forms;

namespace XivMate.DataGathering.ACTLogs.FormsTests
{
    [TestClass]
    public class LogFileParserTests
    {
        [TestMethod]
        public void IsZoneChange_01_Test()
        {
            var logLine = "01|2022-12-20T22:29:32.1650000+00:00|83|Ul'dah - Steps of Thal|15fb5d50efcc680e";

            var parser = new LogFileParser();
            var result = parser.IsZoneChange(logLine);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsZoneChange_40_Test()
        {
            var logLine = "40|2022-12-20T22:29:32.1650000+00:00|83|Ul'dah - Steps of Thal|15fb5d50efcc680e";

            var parser = new LogFileParser();
            var result = parser.IsZoneChange(logLine);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsZoneChange_03_Test()
        {
            var logLine =
                "03|2022-12-20T22:29:32.1650000+00:00|107855D7|Jammy Second|01|3|0000|192|Alpha|0|0|159|159|10000|10000|||34.09|30.10|34.51|-2.52|56e6660fc6268fe2";

            var parser = new LogFileParser();
            var result = parser.IsZoneChange(logLine);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsZoneWeCareAbout_True_Test()
        {
            var logLine =
                "01|2022-12-20T22:29:35.1090000+00:00|33B|the Forbidden Land, Eureka Hydatos|80373af12fdf83e4";

            var parser = new LogFileParser();
            var result = parser.IsZoneWeCareAbout(logLine);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsZoneWeCareAbout_False_Test()
        {
            var logLine = "40|2022-12-20T22:29:32.1650000+00:00|83|Ul'dah - Steps of Thal|15fb5d50efcc680e";

            var parser = new LogFileParser();
            var result = parser.IsZoneWeCareAbout(logLine);

            Assert.IsFalse(result);
        }


        [TestMethod]
        public void FilterLogLine_Version_253_Test()
        {
            var logLine =
                "253|2022-12-20T22:29:25.6624464+00:00|FFXIV_ACT_Plugin Version: 2.6.7.1 (50BCD605C50A749F)|17976907b6fd40e4";
            var expectedResult =
                "253|2022-12-20T22:29:25.6624464+00:00|FFXIV_ACT_Plugin Version: 2.6.7.1 (50BCD605C50A749F)|17976907b6fd40e4";

            var parser = new LogFileParser();
            var result = parser.FilterLogLine(logLine);


            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void FilterLogLine_DebugLog_251_Test()
        {
            var logLine =
                "251|2022-12-20T22:29:25.6624464+00:00|Process ffxiv_dx11 (37100) FINAL FANTASY XIV started on 17/12/2022 22:01:58 Found, Verifying.|30916516de6e8622";
            var expectedResult =
                "251|2022-12-20T22:29:25.6624464+00:00|Process ffxiv_dx11 (37100) FINAL FANTASY XIV started on 17/12/2022 22:01:58 Found, Verifying.|30916516de6e8622";

            var parser = new LogFileParser();
            var result = parser.FilterLogLine(logLine);


            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void FilterLogLine_Settings_249_Test()
        {
            var logLine =
                "249|2022-12-20T22:29:25.6624464+00:00|Selected Language ID: English, Disable Damage Shield: False, Disable Combine Pets: False, Parse Filter: None, DoTCrits: False, RealDoTs: False|6d8c9dbddbf75a07";
            var expectedResult =
                "249|2022-12-20T22:29:25.6624464+00:00|Selected Language ID: English, Disable Damage Shield: False, Disable Combine Pets: False, Parse Filter: None, DoTCrits: False, RealDoTs: False|6d8c9dbddbf75a07";

            var parser = new LogFileParser();
            var result = parser.FilterLogLine(logLine);


            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void FilterLogLine_Party_00_Test()
        {
            var logLine = "00|2022-12-20T23:35:22.0000000+00:00|000E|Geraldine Test|Tyfp <3|9890f61df1f930ba";

            var parser = new LogFileParser();
            var result = parser.FilterLogLine(logLine);


            Assert.IsNull(result, result);
        }

        [TestMethod]
        public void FilterLogLine_Item_00_Test()
        {
            var logLine =
                "00|2022-12-20T23:41:38.0000000+00:00|0839||1 moisture-warped lockbox exchanged for 1 Eurekan potion.|49a85ca18a095451";
            var expectedResult =
                "00|2022-12-20T23:41:38.0000000+00:00|0839||1 moisture-warped lockbox exchanged for 1 Eurekan potion.|49a85ca18a095451";
            var parser = new LogFileParser();
            var result = parser.FilterLogLine(logLine);

            Assert.AreEqual(expectedResult, logLine);
        }
    }
}
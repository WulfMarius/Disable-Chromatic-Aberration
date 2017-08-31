using Harmony;

namespace DisableChromaticAberration
{
    [HarmonyPatch(typeof(UniStormWeatherSystem), "Init")]
    internal class UniStormWeatherSystemInitPatch
    {
        public static void Postfix(UniStormWeatherSystem __instance)
        {
            foreach (WeatherStateConfig eachWeatherStateConfig in __instance.m_WeatherStateConfigs)
            {
                if (eachWeatherStateConfig == null)
                {
                    continue;
                }

                DisableChromaticAberration(eachWeatherStateConfig.m_AfternoonColors);
                DisableChromaticAberration(eachWeatherStateConfig.m_DawnColors);
                DisableChromaticAberration(eachWeatherStateConfig.m_DuskColors);
                DisableChromaticAberration(eachWeatherStateConfig.m_MiddayColors);
                DisableChromaticAberration(eachWeatherStateConfig.m_MorningColors);
                DisableChromaticAberration(eachWeatherStateConfig.m_NightColors);
            }
        }

        private static void DisableChromaticAberration(TODStateConfig config)
        {
            if (config == null)
            {
                return;
            }

            config.m_VignettingChromaticAberration = 0;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace rover
{
    public class Language
    {
        public enum words
        {
            context_draw,
            context_speak,
            context_eat,
            context_sleep,
            context_lick,
            context_haf,
            context_joke,
            context_fact,
            context_search,
            context_exit,
            context_kill,
            context_draw_error,
            context_draw_warn,
            context_draw_rover,
            context_draw_custom,
            context_draw_stop,
            form_speak_settings,
            form_speak_settings_vol,
            form_speak_settings_rate,
            form_speak_settings_win,
            form_speak_text,
            form_speak_text_inside,
            fomr_speak_win,
            form_speak_button,
            context_gdi_filter,
            context_gdi_invert,
            context_gdi_tunnel,
            context_gdi_melting,
            context_gdi_blur,
            context_gdi_erase,
            form_custom_filter_subtitle,
            form_custom_filter_win,
            red,
            green,
            blue,
            custom,
            gray,
            context_gdi_tunnel_slow,
            normal,
            context_gdi_tunnel_fast,
            context_gdi_tunnel_faster,
            form_custom_tunnel_speed,
            form_custom_tunnel_duration,
            form_custom_tunnel_crazy,
            form_custom_tunnel_spiral,
            form_custom_tunnel_inverted,
            form_custom_tunnel_win,
            form_custom_tunnel_text,
            vertical,
            horizontal,
            mix,
            radial,
            zoom,
            use_button,
            clear_button,
            wake_up
        }
        public static Dictionary<words, string> Lang_RU = new Dictionary<words, string>
        {
            { words.context_draw, "Рисовать" },
            { words.context_draw_custom, "Пользовательский значок" },
            { words.context_draw_error, "Значок ошибки" },
            { words.context_draw_rover, "Иконка Ровер" },
            { words.context_draw_stop, "Остановить рисование" },
            { words.context_draw_warn, "Значок предупреждения" },
            { words.context_eat, "Есть" },
            { words.context_exit, "Выход" },
            { words.context_fact, "Расскажите забавный факт" },
            { words.context_gdi_blur, "Размытие" },
            { words.context_gdi_erase, "Стереть" },
            { words.context_gdi_filter, "Фильтр" },
            { words.context_gdi_invert, "инвертировать" },
            { words.context_gdi_melting, "плавление" },
            { words.context_gdi_tunnel, "Туннель" },
            { words.context_gdi_tunnel_fast, "Быстрый" },
            { words.context_gdi_tunnel_faster, "Быстрее" },
            { words.context_gdi_tunnel_slow, "Медленный" },
            { words.context_haf, "Хаф" },
            { words.context_joke, "Рассказать анекдот" },
            { words.context_kill, "Убить ПК" },
            { words.context_lick, "Лизать" },
            { words.context_search, "Поиск в Интернете" },
            { words.context_sleep, "Спать" },
            { words.context_speak, "Говорить" },
            { words.custom, "Обычай" },
            { words.form_custom_filter_subtitle, "Есть" },
            { words.form_custom_tunnel_crazy, "Сумасшедший" },
            { words.form_custom_tunnel_duration, "Продолжительность" },
            { words.form_custom_tunnel_inverted, "Перевернутый" },
            { words.form_custom_tunnel_speed, "Скорость" },
            { words.form_custom_tunnel_spiral, "спираль" },
            { words.form_speak_settings, "Настройки" },
            { words.form_speak_settings_rate, "Ставка" },
            { words.form_speak_settings_vol, "Объем" },
            { words.form_speak_text, "Текст" },
            { words.form_speak_text_inside, "Здравствуйте, меня зовут Ровер, я ваш помощник на рабочем столе. Здесь вы можете написать " +
            "все, что угодно." },
            { words.gray, "Серый" },
            { words.green, "Зеленый" },
            { words.horizontal, "Горизонтальный" },
            { words.mix, "Смешивание" },
            { words.normal, "Нормальный" },
            { words.radial, "Радиальный" },
            { words.red, "Красный" },
            { words.use_button, "Использовать" },
            { words.vertical, "Вертикальный" },
            { words.zoom, "Увеличить" },
            { words.blue, "Синий" },
            { words.form_custom_filter_win, "Пользовательский фильтр" },
            { words.form_custom_tunnel_win, "Пользовательский туннель" },
            { words.form_speak_settings_win, "Настройки преобразования текста в речь (TTS)" },
            { words.fomr_speak_win, "Преобразование текста в речь (TTS)" },
            { words.form_speak_button, "Говорить" },
            { words.clear_button, "Прозрачный" },
            { words.wake_up, "Проснуться" },
            { words.form_custom_tunnel_text, "Установите свой собственный" + Environment.NewLine + "туннельный эффект" }
        };
        public static bool russian_lang = false;
        public static void choosen_lang()
        {
            if (Registry.GetValue(Registry.CurrentUser.ToString() + @"\SOFTWARE\rover", "lang", null).ToString() != "Русский (RU)") return;
            russian_lang = true;
        }
    }
}

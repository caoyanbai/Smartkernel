/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System.Speech.Synthesis;

namespace Smartkernel.Framework
{
    /// <summary>
    /// 广播员：实现语音朗读服务
    /// </summary>
    public static class SmartAnnouncer
    {

        /// <summary>
        /// 语音朗读，支持中文、英文以及中英混合
        /// </summary>
        /// <param name="word">待朗读的文本</param>
        /// <param name="rate">语速，从-10~10</param>
        /// <param name="volume">声音的大小，从0~100</param>
        /// <param name="voiceGender">声音的类型，例如是男士还是女士的声音</param>
        /// <param name="voiceAge">声音的年龄段，例如是成人还是儿童</param>
        public static void Say(string word, int rate = 0, int volume = 50, VoiceGender voiceGender = VoiceGender.Female, VoiceAge voiceAge = VoiceAge.Adult)
        {
            using (var speechSynthesizer = new SpeechSynthesizer())
            {
                speechSynthesizer.Rate = rate;
                speechSynthesizer.Volume = volume;
                speechSynthesizer.SelectVoiceByHints(voiceGender, voiceAge);
                speechSynthesizer.Speak(word);
            }
        }

        /// <summary>
        /// 语音朗读，支持中文、英文以及中英混合（异步）
        /// </summary>
        /// <param name="word">待朗读的文本</param>
        /// <param name="rate">语速，从-10~10</param>
        /// <param name="volume">声音的大小，从0~100</param>
        /// <param name="voiceGender">声音的类型，例如是男士还是女士的声音</param>
        /// <param name="voiceAge">声音的年龄段，例如是成人还是儿童</param>
        /// <returns>语音器</returns>
        public static SpeechSynthesizer SayAsync(string word, int rate = 0, int volume = 50, VoiceGender voiceGender = VoiceGender.Female, VoiceAge voiceAge = VoiceAge.Adult)
        {
            var speechSynthesizer = new SpeechSynthesizer();
            speechSynthesizer.Rate = rate;
            speechSynthesizer.Volume = volume;
            speechSynthesizer.SelectVoiceByHints(voiceGender, voiceAge);
            speechSynthesizer.SpeakCompleted += (object sender, SpeakCompletedEventArgs e) => { speechSynthesizer.Dispose(); };
            speechSynthesizer.SpeakAsync(word);
            return speechSynthesizer;
        }

        /// <summary>
        /// 保存合成的语音
        /// </summary>
        /// <param name="path">合成语音保存的路径，例如：C:\test.wav</param>
        /// <param name="word">待朗读的文本</param>
        /// <param name="rate">语速，从-10~10</param>
        /// <param name="volume">声音的大小，从0~100</param>
        /// <param name="voiceGender">声音的类型，例如是男士还是女士的声音</param>
        /// <param name="voiceAge">声音的年龄段，例如是成人还是儿童</param>
        public static void Save(string path, string word, int rate = 0, int volume = 50, VoiceGender voiceGender = VoiceGender.Female, VoiceAge voiceAge = VoiceAge.Adult)
        {
            using (var speechSynthesizer = new SpeechSynthesizer())
            {
                speechSynthesizer.Rate = rate;
                speechSynthesizer.Volume = volume;
                speechSynthesizer.SelectVoiceByHints(voiceGender, voiceAge);
                speechSynthesizer.SetOutputToWaveFile(path);
            }
        }
   
    }
}

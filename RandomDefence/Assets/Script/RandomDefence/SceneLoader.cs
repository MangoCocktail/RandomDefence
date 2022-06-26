using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace LOR
{
    public static class SceneLoader
    {
        private const string TAG = nameof(SceneLoader);

        public const string PRELOAD = "PreLoad";
        public const string INTRO = "Intro";
        private const string LOADING = "Loading";

        public enum SceneType
        {
            intro,
            Dungeon,
        }

        public enum LoadingStoryboardType
        {
            Immediate,
            Async,
        }

        public delegate void SceneLoadedEvent(Scene scene, LoadSceneMode mode);
        public delegate void TitleSceneLoadedEvent();
        public delegate void StartLoadSceneEvent();
        public delegate void FadeSceneEvent();
        public delegate void FinishLoadSceneEvent();

        /// <summary>
        /// 타이틀 씬 외의 씬 로드 완료 시 호출 (단순 씬 로드 완료로 로딩 화면이 보일수 있음)
        /// </summary>
        public static event SceneLoadedEvent OnSceneLoaded;

        /// <summary>
        /// 타이틀 씬 로드 완료시 호출
        /// </summary>
        public static event TitleSceneLoadedEvent OnTitleSceneLoaded;

        /// <summary>
        /// 씬 이동 시작 전 호출 (로딩 화면 보이기 시작할 때 호출된다)
        /// </summary>
        public static event StartLoadSceneEvent OnStartLoadScene;

        /// <summary>
        /// 씬 이동 완료 시 호출 (로딩 화면까지 사라지고 난 후에 호출)
        /// </summary>
        public static event FinishLoadSceneEvent OnFinishLoadScene;

        /// <summary>
        /// 현재 씬
        /// </summary>
        public static SceneType CurrentType { get; private set; }

        /// <summary>
        /// 현재 씬 이름
        /// </summary>
        private static string currentSceneName;

        public static void LoadIntro()
        {
            CurrentType = SceneType.intro;
            LoadScene(INTRO, LoadingStoryboardType.Immediate);
        }
        
        private static void LoadScene(string sceneName, LoadingStoryboardType storyboardType)
        {
            StopAllCoroutine();

        }

        private static void StopAllCoroutine()
        {            
            //StopAllCoroutines();
        }
    }
}

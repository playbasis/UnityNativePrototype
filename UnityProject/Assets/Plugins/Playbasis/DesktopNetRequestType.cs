namespace Playbasis.Wrapper.Desktop.Net
{
	#if UNITY_STANDALONE_WIN || UNITY_STANDALONE_LINUX || DEBUG_DESKTOP

	public enum RequestType
	{
		Auth,
		Renew,
		Login,
		Logout,
		Register,
		PlayerPublic,
		Player,
		PointOfPlayer,
		QuizList,
		QuizListOfPlayer,
		QuizDetail,
		QuizRandom,
		QuizDoneList,
		QuizPendingList,
		QuizQuestion,
		QuizAnswer,
		Rule,
		Badge,
		Badges,
		GoodsInfo,
		GoodsInfoList,
		QuestInfo,
		QuestInfoList,
		MissionInfo,
		QuestInfoListForPlayer,
		QuestAvailable,
		JoinQuest,
		JoinAllQuests,
		CancelQuest
	};

	#endif
}
using UnityEngine;
using System;
using System.Collections.Generic;
using Playbasis.Wrapper.Model;
using Playbasis.Wrapper.Desktop.Helper;

namespace Playbasis.Wrapper.Desktop.Model 
{
	#if UNITY_STANDALONE_WIN || UNITY_STANDALONE_LINUX || DEBUG_DESKTOP

	public class _quizBasicWr : Migrateable<quizBasicWr>
	{
		public string name {get; set;}
		public string image {get; set;}
		public int weight {get; set;}
		public string description {get; set;}
		public string description_image {get; set;}
		public string quiz_id {get; set;}

		public quizBasicWr Migrate()
		{
			quizBasicWr newc = new quizBasicWr();
			newc.name = name;
			newc.image = image;
			newc.weight = weight;
			newc.description_ = description;
			newc.descriptionImage = description_image;
			newc.quizId = quiz_id;
			return newc;
		}
	}

	public class _quizListWr : Migrateable<quizListWr>
	{
		public List<_quizBasicWr> result {get; set;}

		public quizListWr Migrate()
		{
			quizListWr newc = new quizListWr();
			newc.quizBasicArray = DesktopHelper.MigrateList<quizBasicWr, _quizBasicWr>(result);
			return newc;
		}
	}

	public class _quizWr : _quizBasicWr, Migrateable<quizWr>
	{
		public DateTime date_start {get; set;}
		public DateTime date_expire {get; set;}
		public bool status {get; set;}
		public List<_gradeWr> grades {get; set;}
		public bool deleted {get; set;}
		public uint total_max_score {get; set;}
		public uint total_questions {get; set;}

		public quizWr Migrate()
		{
			quizWr newc = new quizWr();
			newc.basic = base.Migrate();
			newc.dateStart = DesktopHelper.GetTime(date_start);
			newc.dateExpire = DesktopHelper.GetTime(date_expire);
			newc.status = status;
			newc.gradeArray = DesktopHelper.MigrateList<gradeWr, _gradeWr>(grades);
			newc.deleted = deleted;
			newc.totalMaxScore = total_max_score;
			newc.totalQuestion = total_questions;
			return newc;
		}
	}

	public class _gradeWr : Migrateable<gradeWr>
	{
		public string grade_id {get; set;}
		public string start {get; set;}
		public string end {get; set;}
		public string grade {get; set;}
		public string rank {get; set;}
		public string rank_image {get; set;}
		public _gradeRewardsWr rewards {get; set;}

		public gradeWr Migrate()
		{
			gradeWr newc = new gradeWr();
			newc.gradeId = grade_id;
			newc.start = start;
			newc.end = end;
			newc.grade = grade;
			newc.rank = rank;
			newc.rankImage = rank_image;
			newc.rewards = rewards.Migrate();
			return newc;
		}
	}

	public class _gradeRewardsWr : Migrateable<gradeRewardsWr>
	{
		public _gradeRewards_sub_expWr exp {get; set;}
		public _gradeRewards_sub_pointWr point {get; set;}
		// TODO: ignore gradeRewardCustomWr for now ...

		public gradeRewardsWr Migrate()
		{
			gradeRewardsWr newc = new gradeRewardsWr();
			newc.expValue = exp.exp_value;
			newc.pointValue = point.point_value;
			return newc;
		}
	}

	public class _gradeRewards_sub_expWr
	{
		public string exp_value {get; set;}
	}

	public class _gradeRewards_sub_pointWr
	{
		public string point_value {get; set;}
	}

	public class _quizDoneWr : Migrateable<quizDoneWr>
	{
		public uint value {get; set;}
		public _gradeDoneWr grade {get; set;}
		public uint total_completed_questions {get; set;}
		public string quiz_id {get; set;}

		public quizDoneWr Migrate()
		{
			quizDoneWr newc = new quizDoneWr();
			newc.value = value;
			newc.gradeDone = grade.Migrate();
			newc.totalCompletedQuestions = total_completed_questions;
			newc.quizId = quiz_id;
			return newc;
		}
	}

	public class _gradeDoneWr : Migrateable<gradeDoneWr>
	{
		public string grade_id {get; set;}
		public string start {get; set;}
		public string end {get; set;}
		public string grade {get; set;}
		public string rank {get; set;}
		public string rank_image {get; set;}
		public List<_gradeDoneRewardWr> rewards {get; set;}
		public uint score {get; set;}
		public string max_score {get; set;}
		public uint total_score {get; set;}
		public uint total_max_score {get; set;}

		public gradeDoneWr Migrate()
		{
			gradeDoneWr newc = new gradeDoneWr();
			newc.gradeId = grade_id;
			newc.start = start;
			newc.end = end;
			newc.grade = grade;
			newc.rank = rank;
			newc.rankImage = rank_image;
			newc.rewardArray = DesktopHelper.MigrateList<gradeDoneRewardWr, _gradeDoneRewardWr>(rewards);
			newc.score = score;
			newc.maxScore = max_score;
			newc.totalScore = total_score;
			newc.totalMaxScore = total_max_score;
			return newc;
		}
	}

	public class _gradeDoneRewardWr : Migrateable<gradeDoneRewardWr>
	{
		public string event_type {get; set;}
		public string reward_type {get; set;}
		public string reward_id {get; set;}
		public string value {get; set;}

		public gradeDoneRewardWr Migrate()
		{
			gradeDoneRewardWr newc = new gradeDoneRewardWr();
			newc.eventType = event_type;
			newc.rewardType = reward_type;
			newc.rewardId = reward_id;
			newc.value = value;
			return newc;
		}
	}

	public class _quizPendingWr : Migrateable<quizPendingWr>
	{
		public uint value {get; set;}
		public _quizPendingGradeWr grade {get; set;}
		public uint total_completed_questions {get; set;}
		public uint total_pending_questions {get; set;}
		public string quiz_id {get; set;}

		public quizPendingWr Migrate()
		{
			quizPendingWr newc = new quizPendingWr();
			newc.value = value;
			newc.grade = grade.Migrate();
			newc.totalCompletedQuestions = total_completed_questions;
			newc.totalPendingQuestions = total_pending_questions;
			return newc;
		}
	}

	public class _quizPendingGradeWr : Migrateable<quizPendingGradeWr>
	{
		public uint score {get; set;}
		public List<_quizPendingGradeRewardWr> rewards {get; set;}
		public string max_score {get; set;}
		public uint total_score {get; set;}
		public uint total_max_score {get; set;}

		public quizPendingGradeWr Migrate()
		{
			quizPendingGradeWr newc = new quizPendingGradeWr();
			newc.score = score;
			newc.quizPendingGradeRewardArray = DesktopHelper.MigrateList<quizPendingGradeRewardWr, _quizPendingGradeRewardWr>(rewards);
			newc.maxScore = max_score;
			newc.totalScore = total_score;
			newc.totalMaxScore = total_max_score;
			return newc;
		}
	}

	public class _quizPendingGradeRewardWr : Migrateable<quizPendingGradeRewardWr>
	{
		public string event_type;
		public string reward_type;
		public string reward_id;
		public string value;

		public quizPendingGradeRewardWr Migrate()
		{
			quizPendingGradeRewardWr newc = new quizPendingGradeRewardWr();
			newc.eventType = event_type;
			newc.rewardType = reward_type;
			newc.rewardId = reward_id;
			newc.value = value;
			return newc;
		}
	}

	public class _questionWr : Migrateable<questionWr>
	{
		public string question {get; set;}
		public string question_image {get; set;}
		public List<_questionOptionWr> options {get; set;}
		public uint index {get; set;}
		public uint total {get; set;}
		public string question_id {get; set;}

		public questionWr Migrate()
		{
			questionWr newc = new questionWr();
			newc.question = question;
			newc.questionImage = question_image;
			newc.optionArray = DesktopHelper.MigrateList<questionOptionWr, _questionOptionWr>(options);
			newc.index = index;
			newc.total = total;
			newc.questionId = question_id;
			return newc;
		}
	}

	public class _questionOptionWr : Migrateable<questionOptionWr>
	{
		public string option {get; set;}
		public string option_image {get; set;}
		public string option_id {get; set;}

		public questionOptionWr Migrate()
		{
			questionOptionWr newc = new questionOptionWr();
			newc.option = option;
			newc.optionImage = option_image;
			newc.optionId = option_id;
			return newc;
		}
	}

	public class _questionAnsweredWr : Migrateable<questionAnsweredWr>
	{
		public List<_questionAnsweredOptionWr> options {get; set;}
		public uint score {get; set;}
		public string max_score {get; set;}
		public string explanation {get; set;}
		public uint total_score {get; set;}
		public uint total_max_score {get; set;}
		public _questionAnsweredGradeDoneWr grade {get; set;}
		public List<_gradeDoneRewardWr> rewards {get; set;}

		public questionAnsweredWr Migrate()
		{
			questionAnsweredWr newc = new questionAnsweredWr();
			newc.optionArray = DesktopHelper.MigrateList<questionAnsweredOptionWr, _questionAnsweredOptionWr>(options);
			newc.score = score;
			newc.maxScore = max_score;
			newc.explanation = explanation;
			newc.totalScore = total_score;
			newc.totalMaxScore = total_max_score;
			newc.gradeDone = grade.Migrate();
			newc.gradeDoneRewardArray = DesktopHelper.MigrateList<gradeDoneRewardWr, _gradeDoneRewardWr>(rewards);
			return newc;
		}
	}

	public class _questionAnsweredOptionWr : Migrateable<questionAnsweredOptionWr>
	{
		public string option {get; set;}
		public string score {get; set;}
		public string explanation {get; set;}
		public string option_image {get; set;}
		public string option_id {get; set;}

		public questionAnsweredOptionWr Migrate()
		{
			questionAnsweredOptionWr newc = new questionAnsweredOptionWr();
			newc.option = option;
			newc.score = score;
			newc.explanation = explanation;
			newc.optionImage = option_image;
			newc.optionId = option_id;
			return newc;
		}
	}

	public class _questionAnsweredGradeDoneWr : Migrateable<questionAnsweredGradeDoneWr>
	{
		public string grade_id {get; set;}
		public string start {get; set;}
		public string end {get; set;}
		public string grade {get; set;}
		public string rank {get; set;}
		public string rank_image {get; set;}
		public uint score {get; set;}
		public string max_score {get; set;}
		public uint total_score {get; set;}
		public uint total_max_score {get; set;}

		public questionAnsweredGradeDoneWr Migrate()
		{
			questionAnsweredGradeDoneWr newc = new questionAnsweredGradeDoneWr();
			newc.gradeId = grade_id;
			newc.start = start;
			newc.end = end;
			newc.grade = grade;
			newc.rank = rank;
			newc.rankImage = rank_image;
			newc.score = score;
			newc.maxScore = max_score;
			newc.totalScore = total_score;
			newc.totalMaxScore = total_max_score;
			return newc;
		}
	}

	#endif
}
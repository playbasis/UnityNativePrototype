using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using AOT;

namespace Playbasis.Wrapper.Model {
	/*
		Structs
		- Arrays
	*/
	[StructLayout(LayoutKind.Sequential)]
	public struct pointArrayWr {
		#if UNITY_IOS || UNITY_STANDALONE_OSX
		public IntPtr data;
		#elif UNITY_ANDROID
		public List<pointWr> data;
		#endif

		public int count;

		#if UNITY_ANDROID
		public void setFinalList(List<pointWr> list)
		{
			data = list;
			count = data.Count;
		}
		#endif

		public pointWr itemAt(int i)
		{
			#if UNITY_IOS || UNITY_STANDALONE_OSX
			IntPtr ptr = (IntPtr)((long)data + Marshal.SizeOf(typeof(pointWr))*i);
			return (pointWr)Marshal.PtrToStructure(ptr, typeof(pointWr));
			#elif UNITY_ANDROID
			return data[i];
			#endif
		}

		public string toString()
		{
			string s = "pointArrayWr{";

			if (count > 0)
			{
				for (int i=0; i<count; i++)
				{
					pointWr p = itemAt(i);
					s += p.toString();

					if (i < count - 1)
					{
						s += ", ";
					}
				}
			}
			s += "}";
			return s;
		}
	};
	
	[StructLayout(LayoutKind.Sequential)]
	public struct quizBasicArrayWr {
		#if UNITY_IOS || UNITY_STANDALONE_OSX
		public IntPtr data;
		#elif UNITY_ANDROID
		public List<quizBasicWr> data;
		#endif

		public int count;

		#if UNITY_ANDROID
		public void setFinalList(List<quizBasicWr> list)
		{
			data = list;
			count = data.Count;
		}
		#endif

		public quizBasicWr itemAt(int i)
		{
			#if UNITY_IOS || UNITY_STANDALONE_OSX
			IntPtr ptr = (IntPtr)((long)data + Marshal.SizeOf(typeof(quizBasicWr))*i);
			return (quizBasicWr)Marshal.PtrToStructure(ptr, typeof(quizBasicWr));
			#elif UNITY_ANDROID
			return data[i];
			#endif
		}

		public string toString()
		{
			string s = "quizBasicArrayWr{";

			if (count > 0)
			{
				for (int i=0; i<count; i++)
				{
					quizBasicWr p = itemAt(i);
					s += p.toString();

					if (i < count - 1)
					{
						s += ", ";
					}
				}
			}
			s += "}";
			return s;
		}
	};

	[StructLayout(LayoutKind.Sequential)]
	public struct gradeArrayWr {
		public IntPtr data;
		public int count;

		public gradeWr itemAt(int i)
		{
			IntPtr ptr = (IntPtr)((long)data + Marshal.SizeOf(typeof(gradeWr))*i);
			return (gradeWr)Marshal.PtrToStructure(ptr, typeof(gradeWr));
		}
	};

	[StructLayout(LayoutKind.Sequential)]
	public struct gradeRewardCustomArrayWr {
		public IntPtr data;
		public int count;

		public gradeRewardCustomWr itemAt(int i)
		{
			IntPtr ptr = (IntPtr)((long)data + Marshal.SizeOf(typeof(gradeRewardCustomWr))*i);
			return (gradeRewardCustomWr)Marshal.PtrToStructure(ptr, typeof(gradeRewardCustomWr));
		}
	};
	[StructLayout(LayoutKind.Sequential)]
	public struct quizDoneListWr {
		public IntPtr data;
		public int count;

		public quizDoneWr itemAt(int i)
		{
			IntPtr ptr = (IntPtr)((long)data + Marshal.SizeOf(typeof(quizDoneWr))*i);
			return (quizDoneWr)Marshal.PtrToStructure(ptr, typeof(quizDoneWr));
		}
	};
	[StructLayout(LayoutKind.Sequential)]
	public struct gradeDoneRewardArrayWr {
		public IntPtr data;
		public int count;

		public gradeDoneRewardWr itemAt(int i)
		{
			IntPtr ptr = (IntPtr)((long)data + Marshal.SizeOf(typeof(gradeDoneRewardWr))*i);
			return (gradeDoneRewardWr)Marshal.PtrToStructure(ptr, typeof(gradeDoneRewardWr));
		}
	};
	[StructLayout(LayoutKind.Sequential)]
	public struct quizPendingGradeRewardArrayWr {
		public IntPtr data;
		public int count;

		public quizPendingGradeRewardWr itemAt(int i)
		{
			IntPtr ptr = (IntPtr)((long)data + Marshal.SizeOf(typeof(quizPendingGradeRewardWr))*i);
			return (quizPendingGradeRewardWr)Marshal.PtrToStructure(ptr, typeof(quizPendingGradeRewardWr));
		}
	}
	[StructLayout(LayoutKind.Sequential)]
	public struct quizPendingListWr {
		public IntPtr data;
		public int count;

		public quizPendingWr itemAt(int i)
		{
			IntPtr ptr = (IntPtr)((long)data + Marshal.SizeOf(typeof(quizPendingWr))*i);
			return (quizPendingWr)Marshal.PtrToStructure(ptr, typeof(quizPendingWr));
		}
	};
	[StructLayout(LayoutKind.Sequential)]
	public struct questionOptionArrayWr {
		public IntPtr data;
		public int count;

		public questionOptionWr itemAt(int i)
		{
			IntPtr ptr = (IntPtr)((long)data + Marshal.SizeOf(typeof(questionOptionWr))*i);
			return (questionOptionWr)Marshal.PtrToStructure(ptr, typeof(questionOptionWr));
		}
	};
	[StructLayout(LayoutKind.Sequential)]
	public struct questionAnsweredOptionArrayWr {
		public IntPtr data;
		public int count;

		public questionAnsweredOptionWr itemAt(int i)
		{
			IntPtr ptr = (IntPtr)((long)data + Marshal.SizeOf(typeof(questionAnsweredOptionWr))*i);
			return (questionAnsweredOptionWr)Marshal.PtrToStructure(ptr, typeof(questionAnsweredOptionWr));
		}
	}
	[StructLayout(LayoutKind.Sequential)]
	public struct questionAnsweredGradeDoneArrayWr {
		public IntPtr data;
		public int count;

		public questionAnsweredGradeDoneWr itemAt(int i)
		{
			IntPtr ptr = (IntPtr)((long)data + Marshal.SizeOf(typeof(questionAnsweredGradeDoneWr))*i);
			return (questionAnsweredGradeDoneWr)Marshal.PtrToStructure(ptr, typeof(questionAnsweredGradeDoneWr));
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct ruleEventArrayWr {
		public IntPtr data;
		public int count;

		public ruleEventWr itemAt(int i)
		{
			IntPtr ptr = (IntPtr)((long)data + Marshal.SizeOf(typeof(ruleEventWr))*i);
			return (ruleEventWr)Marshal.PtrToStructure(ptr, typeof(ruleEventWr));
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct ruleEventMissionArrayWr {
		public IntPtr data;
		public int count;

		public ruleEventMissionWr itemAt(int i)
		{
			IntPtr ptr = (IntPtr)((long)data + Marshal.SizeOf(typeof(ruleEventMissionWr))*i);
			return (ruleEventMissionWr)Marshal.PtrToStructure(ptr, typeof(ruleEventMissionWr));
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct ruleEventQuestArrayWr {
		public IntPtr data;
		public int count;

		public ruleEventQuestWr itemAt(int i)
		{
			IntPtr ptr = (IntPtr)((long)data + Marshal.SizeOf(typeof(ruleEventQuestWr))*i);
			return (ruleEventQuestWr)Marshal.PtrToStructure(ptr, typeof(ruleEventQuestWr));
		}
	}

	/*
		Structs
		-	Normal data model
	*/
	[StructLayout(LayoutKind.Sequential)]
	public struct playerBasicWr {
		public string image;
		public string userName;
		public uint exp;
		public uint level;
		public string firstName;
		public string lastName;
		public uint gender;
		public string clPlayerId;

		public string toString()
		{
			return "playerBasicWr{" +
					"image='" + image + "'" +
					", userName='" + userName + "'" +
					", exp='" + exp + "'" +
					", level='" + level + "'" +
					", firstName='" + firstName + "'" +
					", lastName='" + lastName + "'" +
					", gender='" + gender + "'" +
					", clPlayerId='" + clPlayerId + "'" +
					"}";
		}
	};

	[StructLayout(LayoutKind.Sequential)]
	public struct playerPublicWr {
		public playerBasicWr basic;
		public long registered;
		public long lastLogin;
		public long lastLogout;

		public string toString()
		{
			return "playerPublicWr{" +
					basic.toString() +
					", registered='" + registered + "'" +
					", lastLogin='" + lastLogin + "'" +
					", lastLogout='" + lastLogout + "'" +
					"}";
		}
	};

	[StructLayout(LayoutKind.Sequential)]
	public struct playerWr {
		public playerPublicWr playerPublic;
		public string email;
		public string phoneNumber;

		public string toString()
		{
			return "playerWr{" +
					playerPublic.toString() +
					", email='" + email + "'" +
					", phoneNumber='" + phoneNumber + "'" +
					"}";
		}
	};

	[StructLayout(LayoutKind.Sequential)]
	public struct pointWr {
		public string rewardId;
		public string rewardName;
		public uint value;

		public string toString()
		{
			return "pointWr{" +
					"rewardId='" + rewardId + "'" +
					", rewardName='" + rewardName + "'" +
					"}";
		}
	};

	[StructLayout(LayoutKind.Sequential)]
	public struct pointRWr {
		public pointArrayWr pointArray;

		public string toString()
		{
			return "pointRWr{" +
					pointArray.toString() +
					"}";
		}
	};

	[StructLayout(LayoutKind.Sequential)]
	public struct quizBasicWr {
		public string name;
		public string image;
		public int weight;
		public string description_;
		public string descriptionImage;
		public string quizId;

		public string toString()
		{
			return "quizBasicWr{" +
					"name='" + name + "'" +
					", image='" + image + "'" +
					", weight='" + weight + "'" +
					", description_='" + description_ + "'" +
					", descriptionImage='" + descriptionImage + "'" +
					", quizId='" + quizId + "'" +
					"}";
		}
	};

	[StructLayout(LayoutKind.Sequential)]
	public struct gradeRewardCustomWr {
		public string customId;
		public string customValue;

		public string toString()
		{
			return "gradeRewardCustomWr{" +
					"customId='" + customId + "'" +
					", customValue='" + customValue + "'" +
					"}";
		}
	};

	[StructLayout(LayoutKind.Sequential)]
	public struct gradeRewardsWr {
		public string expValue;
		public string pointValue;
		public gradeRewardCustomArrayWr gradeRewardCustomArray;
	};

	[StructLayout(LayoutKind.Sequential)]
	public struct gradeWr {
		public string gradeId;
		public string start;
		public string end;
		public string grade;
		public string rank;
		public string rankImage;
		public gradeRewardsWr rewards;
	};

	[StructLayout(LayoutKind.Sequential)]
	public struct quizWr {
		public quizBasicWr basic;
		public long dateStart;
		public long dateExpire;
		public bool status;
		public gradeArrayWr gradeArray;
		public bool deleted;
		public uint totalMaxScore;
		public uint totalQuestion;
	};

	[StructLayout(LayoutKind.Sequential)]
	public struct quizListWr {
		public quizBasicArrayWr quizBasicArray;

		public string toString()
		{
			return "quizListWr{" +
					quizBasicArray.toString() +
					"}";
		}
	};

	[StructLayout(LayoutKind.Sequential)]
	public struct gradeDoneRewardWr {
		public string eventType;
		public string rewardType;
		public string rewardId;
		public string value;
	};

	[StructLayout(LayoutKind.Sequential)]
	public struct gradeDoneWr {
		public string gradeId;
		public string start;
		public string end;
		public string grade;
		public string rank;
		public string rankImage;
		public gradeDoneRewardArrayWr rewardArray;
		public uint score;
		public string maxScore;
		public uint totalScore;
		public uint totalMaxScore;
	};

	[StructLayout(LayoutKind.Sequential)]
	public struct quizDoneWr {
		public uint value;
		public gradeDoneWr gradeDone;
	};

	[StructLayout(LayoutKind.Sequential)]
	public struct quizPendingGradeRewardWr {
		public string eventType;
		public string rewardType;
		public string rewardId;
		public string value;
	};

	[StructLayout(LayoutKind.Sequential)]
	public struct quizPendingGradeWr {
		public uint score;
		public quizPendingGradeRewardArrayWr quizPendingGradeRewardArray;
		public string maxScore;
		public uint totalScore;
		public uint totalMaxScore;
	};

	[StructLayout(LayoutKind.Sequential)]
	public struct quizPendingWr {
		public uint value;
		public quizPendingGradeWr grade;
		public uint totalCompletedQuestions;
		public uint totalPendingQuestions;
		public string quizId;
	};

	[StructLayout(LayoutKind.Sequential)]
	public struct questionOptionWr {
		public string option;
		public string optionImage;
		public string optionId;
	};

	[StructLayout(LayoutKind.Sequential)]
	public struct questionWr {
		public string question;
		public string questionImage;
		public questionOptionArrayWr optionArray;
		public uint index;
		public uint total;
		public string questionId;
	};

	[StructLayout(LayoutKind.Sequential)]
	public struct questionAnsweredGradeDoneWr {
		public string gradeId;
		public string start;
		public string end;
		public string grade;
		public string rank;
		public string rankImage;
		public uint score;
		public string maxScore;
		public uint totalScore;
		public uint totalMaxScore;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct questionAnsweredOptionWr {
		public string option;
		public string score;
		public string explanation;
		public string optionImage;
		public string optionId;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct questionAnsweredWr {
		public questionAnsweredOptionArrayWr optionArray;
		public uint score;
		public string maxScore;
		public string explanation;
		public uint totalScore;
		public uint totalMaxScore;
		public questionAnsweredGradeDoneArrayWr gradeDoneArray;
		public gradeDoneRewardArrayWr gradeDoneRewardArray;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct ruleEventWr {
		public string eventType;
		public string rewardType;
		public string value;
		public IntPtr rewardData;
		public int index;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct ruleEventMissionWr {
		public ruleEventArrayWr eventArray;
		public string missionId;
		public string missionNumber;
		public string missionName;
		public string description_;
		public string hint;
		public string image;
		public string questId;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct ruleEventQuestWr {
		public ruleEventArrayWr eventArray;
		public string questId;
		public string questName;
		public string description_;
		public string hint;
		public string image;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct ruleWr {
		public ruleEventArrayWr ruleEventArray;
		public ruleEventMissionWr ruleEventMissionArray;
		public ruleEventQuestWr ruleEventQuestArray;
	}
}
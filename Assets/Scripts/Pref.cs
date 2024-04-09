using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Pref 
{
  public static int bestScore1
  {
        get => PlayerPrefs.GetInt(GameConsts.BEST_SCORE_1, 0);

        set
        {
            int curScore = PlayerPrefs.GetInt(GameConsts.BEST_SCORE_1);

            if (value > curScore)
            {
                PlayerPrefs.SetInt(GameConsts.BEST_SCORE_1, value);
            }
        }
   }

   public static int bestScore2
    {
        get => PlayerPrefs.GetInt(GameConsts.BEST_SCORE_1, 0);

        set
        {
            int curScore = PlayerPrefs.GetInt(GameConsts.BEST_SCORE_1);

            if (value > curScore)
            {
                PlayerPrefs.SetInt(GameConsts.BEST_SCORE_1, value);
            }
        }
   }

    public static int bestScore3
    {
        get => PlayerPrefs.GetInt(GameConsts.BEST_SCORE_3, 0);

        set
        {
            int curScore = PlayerPrefs.GetInt(GameConsts.BEST_SCORE_3);

            if (value > curScore)
            {
                PlayerPrefs.SetInt(GameConsts.BEST_SCORE_3, value);
            }
        }
    }

    public static int bestScore4
    {
        get => PlayerPrefs.GetInt(GameConsts.BEST_SCORE_4, 0);

        set
        {
            int curScore = PlayerPrefs.GetInt(GameConsts.BEST_SCORE_4);

            if (value > curScore)
            {
                PlayerPrefs.SetInt(GameConsts.BEST_SCORE_4, value);
            }
        }
    }


    public static int level
   {
        get => PlayerPrefs.GetInt(GameConsts.LEVEL, 1);
        set
        {
            int curLevel = PlayerPrefs.GetInt(GameConsts.LEVEL);
            if (value > curLevel)
            {
                PlayerPrefs.SetInt(GameConsts.LEVEL, value);
            }
        }
   }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTransforms : MonoBehaviour
{
    public GameObject TransformPanel;
    public GameObject Player;
    public GameObject gameController;
    public GameObject slime;
    public GameObject skeleton;
    public Stat skeletonBaseArmor;
    public Stat skeletonBaseAttack;
    public GameObject human;
    public Stat humanBaseArmor;
    public Stat humanBaseAttack;
    public GameObject currentForm;
    public GameObject slimeSkillBar;
    public GameObject skeletonSkillBar;
    public GameObject humanSkillBar;



    /*public void TransformSkill()
    {
        TransformPanel.SetActive(true);
        Time.timeScale = .05f;
    }

    public void TransformFinish()
    {
        //TransformPanel.SetActive(false);
        slime.GetComponent<SlimeSkills>().SkillFourUsed();
        //all transform types needs this
        Time.timeScale = 1f;
    }

    public void SlimeForm()
    {
        skeleton.SetActive(false);
        skeletonSkillBar.SetActive(false);
        human.SetActive(false);
        humanSkillBar.SetActive(false);
        slime.SetActive(true);
        slimeSkillBar.SetActive(true);
        TransformFinish();
        PlayerAnimator.instance.animator = slime.GetComponent<Animator>();

    }

    public void HumanForm()
    {
        skeleton.SetActive(false);
        skeletonSkillBar.SetActive(false);
        human.SetActive(true);
        humanSkillBar.SetActive(true);
        slime.SetActive(false);
        slimeSkillBar.SetActive(false);
        TransformFinish();
        PlayerAnimator.instance.animator = human.GetComponent<Animator>();

        currentForm = human;
    }

    public void SkeletonForm()
    {
        skeleton.SetActive(true);
        skeletonSkillBar.SetActive(true);
        human.SetActive(false);
        humanSkillBar.SetActive(false);
        slime.SetActive(false);
        slimeSkillBar.SetActive(false);
        TransformFinish();
        PlayerAnimator.instance.animator = skeleton.GetComponent<Animator>();

        currentForm = skeleton;
    }
    */

}

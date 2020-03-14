using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlimeSkills : MonoBehaviour
{
    /*
    public GameObject gameController;
    public GameObject player;
    public List<Skills> allSkills;

    public Stat slimeBaseArmor;
    public Stat slimeBaseAttack;
    public Stat slimeArmor;
    public Stat slimeAttack;

    public Image skillOneCooldownImage;
    public Image skillTwoCooldownImage;
    public Image skillThreeCooldownImage;
    public Image skillFourCooldownImage;
    public GameObject skillOneHighlightImage;
    public GameObject skillTwoHighlightImage;
    public GameObject skillThreeHighlightImage;
    public GameObject skillFourHighlightImage;

    public GameObject skillOneButton;
    public GameObject skillTwoButton;
    public GameObject skillThreeButton;
    public GameObject skillFourButton;

    Camera cam;
    #region SkillLevels
    public int slimeLevel;
    public int skeletonLevel;
    public int humanLevel;
    public int bladeLevel;
    public int bludgeonLevel;
    public int shootLevel;
    #endregion

    #region SkillUnlocks
    bool skillTwoUnlocked = false;
    bool skillThreeUnlocked = false;
    bool skillFourUnlocked = false;
    #endregion

    bool skillTwoUsed = false;
    bool skillThreeUsed = false;
    bool skillFourUsed = false;

    #region SkillRangeAndDamage
    int skillOneDamage;
    float skillOneRange = 0;
    int skillTwoDamage;
    float skillTwoRange = 0;
    int skillThreeDamage;
    float skillThreeRange = 10f;
    #endregion

    #region SkillTimers
    float skillOneTimer;
    public float skillOneCooldownTime;
    bool skillOneOnCD;
    float skillTwoTimer;
    public float skillTwoCooldownTime;
    bool skillTwoOnCD;
    float skillThreeTimer;
    public float skillThreeCooldownTime;
    bool skillThreeOnCD;
    float skillFourTimer;
    public float skillFourCooldownTime;
    bool skillFourOnCD;
    #endregion

    private void OnEnable()
    {
        ResetCooldowns();
        if (!skillFourUnlocked)
        {
            skillFourButton.SetActive(false);
        }
        if (!skillThreeUnlocked)
        {
            skillThreeButton.SetActive(false);
        }
        if (!skillTwoUnlocked)
        {
            skillTwoButton.SetActive(false);
        }
        allSkills = gameController.GetComponent<PlayerExp>().allSkills;
        slimeLevel = allSkills.Find(x => x.id == 100).level;
        skeletonLevel = allSkills.Find(x => x.id == 102).level;
        humanLevel = allSkills.Find(x => x.id == 101).level;
        bladeLevel = allSkills.Find(x => x.id == 200).level;
        bludgeonLevel = allSkills.Find(x => x.id == 201).level;
        shootLevel = allSkills.Find(x => x.id == 202).level;
        slimeArmor.baseValue = slimeBaseArmor.baseValue + slimeLevel;
        slimeAttack.baseValue = slimeBaseAttack.baseValue + slimeLevel;
        player.GetComponent<PlayerStats>().UpdateStats((slimeArmor), slimeAttack);

        if (skeletonLevel > 0 || humanLevel > 0)
        {
            skillFourUnlocked = true;
            skillFourButton.SetActive(true);
        }
        if (shootLevel > 0)
        {
            skillThreeUnlocked = true;
            skillThreeButton.SetActive(true);
        }
        if (bladeLevel > 0 || bludgeonLevel > 0)
        {
            skillTwoUnlocked = true;
            skillTwoButton.SetActive(true);
        }

    }

    public void LevelUp()
    {
        if (!skillFourUnlocked)
        {
            skillFourButton.SetActive(false);
        }
        if (!skillThreeUnlocked)
        {
            skillThreeButton.SetActive(false);
        }
        if (!skillTwoUnlocked)
        {
            skillTwoButton.SetActive(false);
        }
        ResetCooldowns();
        allSkills = gameController.GetComponent<PlayerExp>().allSkills;
        slimeLevel = allSkills.Find(x => x.id == 100).level;
        skeletonLevel = allSkills.Find(x => x.id == 102).level;
        humanLevel = allSkills.Find(x => x.id == 101).level;
        bladeLevel = allSkills.Find(x => x.id == 200).level;
        bludgeonLevel = allSkills.Find(x => x.id == 201).level;
        shootLevel = allSkills.Find(x => x.id == 202).level;

        slimeArmor.baseValue = slimeBaseArmor.baseValue + slimeLevel;
        slimeAttack.baseValue = slimeBaseAttack.baseValue + slimeLevel;
        player.GetComponent<PlayerStats>().UpdateStats((slimeArmor), slimeAttack);

        if (skeletonLevel > 0 || humanLevel > 0)
        {
            skillFourUnlocked = true;
            skillFourButton.SetActive(true);
        }
        if (shootLevel > 0)
        {
            skillThreeUnlocked = true;
            skillThreeButton.SetActive(true);
        }
        if (bladeLevel > 0 || bludgeonLevel > 0)
        {
            skillTwoUnlocked = true;
            skillTwoButton.SetActive(true);
        }

    }

    private void Start()
    {
        if(!skillFourUnlocked)
        {
            skillFourButton.SetActive(false);
        }
        if (!skillThreeUnlocked)
        {
            skillThreeButton.SetActive(false);
        }
        if (!skillTwoUnlocked)
        {
            skillTwoButton.SetActive(false);
        }
        ResetCooldowns();
        cam = Camera.main;
        //if skill bools unlocked then button turns on
        allSkills = gameController.GetComponent<PlayerExp>().allSkills;
        slimeLevel = allSkills.Find(x => x.id == 100).level;
        skeletonLevel = allSkills.Find(x => x.id == 102).level;
        humanLevel = allSkills.Find(x => x.id == 101).level;
        bladeLevel = allSkills.Find(x => x.id == 200).level;
        bludgeonLevel = allSkills.Find(x => x.id == 201).level;
        shootLevel = allSkills.Find(x => x.id == 202).level;

        slimeArmor.baseValue = slimeBaseArmor.baseValue + slimeLevel;
        slimeAttack.baseValue = slimeBaseAttack.baseValue + slimeLevel;
        player.GetComponent<PlayerStats>().UpdateStats((slimeArmor), slimeAttack);

        if (skeletonLevel > 0 || humanLevel > 0)
        {
            skillFourUnlocked = true;
            skillFourButton.SetActive(true);
        }
        if (shootLevel > 0)
        {
            skillThreeUnlocked = true;
            skillThreeButton.SetActive(true);
        }
        if (bladeLevel > 0 || bludgeonLevel > 0)
        {
            skillTwoUnlocked = true;
            skillTwoButton.SetActive(true);
        }
    }

    private void ResetCooldowns()
    {
        skillOneTimer = 0f;
        skillTwoTimer = 0f;
        skillThreeTimer = 0f;
        skillFourTimer = 0f;
        skillOneCooldownImage.fillAmount = 0;
        skillTwoCooldownImage.fillAmount = 0;
        skillThreeCooldownImage.fillAmount = 0;
        skillFourCooldownImage.fillAmount = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SkillOne();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SkillTwo();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SkillThree();
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SkillFour();
        }

        if (skillOneOnCD)
        {
            if (skillOneTimer > 0)
            {
                skillOneTimer -= Time.deltaTime;
                skillOneCooldownImage.fillAmount = 1 - (skillOneTimer / skillOneCooldownTime);
            }
            else
            {
                skillOneOnCD = false;
                skillOneCooldownImage.fillAmount = 0;
            }
        }

        if (skillTwoOnCD)
        {
            if (skillTwoTimer > 0)
            {
                skillTwoTimer -= Time.deltaTime;
                skillTwoCooldownImage.fillAmount = (skillTwoTimer / skillTwoCooldownTime);
            }
            else
            {
                skillTwoOnCD = false;
                skillTwoCooldownImage.fillAmount = 0;
            }
        }

        if (skillThreeOnCD)
        {
            if (skillThreeTimer > 0)
            {
                skillThreeTimer -= Time.deltaTime;
                skillThreeCooldownImage.fillAmount = (skillThreeTimer / skillThreeCooldownTime);
            }
            else
            {
                skillThreeOnCD = false;
                skillThreeCooldownImage.fillAmount = 0;
            }
        }

        if (skillFourOnCD)
        {
            if (skillFourTimer > 0)
            {
                skillFourTimer -= Time.deltaTime;
                skillFourCooldownImage.fillAmount = (skillFourTimer / skillFourCooldownTime);
            }
            else
            {
                skillFourOnCD = false;
                skillFourUsed = false;
                skillFourCooldownImage.fillAmount = 0;
            }
        }

    }

    public void SkillsUsed()
    {
        SkillTwoUsed();
        SkillThreeUsed();
        SkillFourUsed();
    }

    public void SkillOne()
    {
        if (gameController.GetComponent<Inventory>().absorbing == true)
        {
            gameController.GetComponent<Inventory>().absorbing = false;
            skillOneHighlightImage.SetActive(false);
            Debug.Log("Absorb off");
        } else if (gameController.GetComponent<Inventory>().absorbing == false)
        {
            gameController.GetComponent<Inventory>().absorbing = true;
            Debug.Log("Absorb On");
            skillOneHighlightImage.SetActive(true);
        }
    }


    public void SkillTwo()
    {
        if (skillTwoUnlocked && !skillTwoUsed && !skillTwoOnCD)
        {
            skillTwoHighlightImage.SetActive(true);
            skillTwoDamage = player.GetComponent<PlayerStats>().damage.baseValue;
            skillTwoDamage += slimeLevel;
            skillTwoDamage += bladeLevel;
            skillTwoDamage += bludgeonLevel;
            player.GetComponent<PlayerStats>().damage.AddModifier(skillTwoDamage);
            player.GetComponent<PlayerController>().attackRange = skillTwoRange;
            skillTwoUsed = true;
        }
    }

    public void SkillTwoUsed()
    {

        if (skillTwoUsed)
        {
            skillTwoHighlightImage.SetActive(false);
            skillTwoOnCD = true;
            skillTwoTimer = skillTwoCooldownTime;
            skillTwoDamage = player.GetComponent<PlayerStats>().damage.baseValue;
            skillTwoDamage += slimeLevel;
            skillTwoDamage += bladeLevel;
            skillTwoDamage += bludgeonLevel;
            player.GetComponent<PlayerStats>().damage.RemoveModifier(skillTwoDamage);
            player.GetComponent<PlayerController>().attackRange = player.GetComponent<PlayerController>().baseAttackRange;
            skillTwoUsed = false;
            player.GetComponent<PlayerController>().SkillUsed();
        }

    }

    public void SkillThree()
    {
        if (skillThreeUnlocked && !skillThreeUsed && !skillThreeOnCD)
        {
            skillThreeHighlightImage.SetActive(true);
            skillThreeDamage = 0;
            skillThreeDamage += slimeLevel;
            skillThreeDamage += shootLevel;

            player.GetComponent<PlayerStats>().damage.AddModifier(skillThreeDamage);
            player.GetComponent<PlayerController>().attackRange = skillThreeRange;
            skillThreeUsed = true;
            player.GetComponent<PlayerController>().SkillUsed();
        }
    }

    public void SkillThreeUsed()
    {
        if (skillThreeUsed)
        {
            skillThreeHighlightImage.SetActive(false);
            skillThreeOnCD = true;
            skillThreeTimer = skillThreeCooldownTime;
            skillThreeDamage = 0;
            skillThreeDamage += slimeLevel;
            skillThreeDamage += shootLevel;
            player.GetComponent<PlayerStats>().damage.RemoveModifier(skillThreeDamage);
            player.GetComponent<PlayerController>().attackRange = player.GetComponent<PlayerController>().baseAttackRange;
            skillThreeUsed = false;
            player.GetComponent<PlayerController>().SkillUsed();
        }

    }

    public void SkillFour()
    {
        if (skillFourUnlocked && !skillFourOnCD)
        {
            player.GetComponent<PlayerTransforms>().TransformSkill();
            skillFourUsed = true;
            skillFourHighlightImage.SetActive(true);
        }
    }

    public void SkillFourUsed()
    {
        if (skillFourUsed)
        {
            skillFourHighlightImage.SetActive(false);
        }
    }
    */
}

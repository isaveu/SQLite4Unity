using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;

public class PhoneInfo
{
    public int id;
    public string MobileArea;
    public string MobileType;
    public string AreaCode;
    public string PostCode;
}

public class IdentitycardInfo
{
    public int id;
    public string address;
}

public class Test : MonoBehaviour
{
    public InputField input;
    public Text text;
    public Dropdown dropdown;

    private int mIndex = 0;
    private Dictionary<string, string[]> mDict = null;

    public void ClickButton()
    {
        mIndex = dropdown.value;
        if (mIndex == 0)
        {
            string number = GetSearchNumber(7);
            if (!string.IsNullOrEmpty(number))
            {
                PhoneInfo phoneinfo = TableManager.Instance.GetTableData<PhoneInfo>(eTableName.phone, number);
                text.text = string.Format("{0} {1}", phoneinfo.MobileArea, phoneinfo.MobileType);
            }

        }
        else
        {
            string number = GetSearchNumber(6);
            if (!string.IsNullOrEmpty(number))
            {
                IdentitycardInfo info = TableManager.Instance.GetTableData<IdentitycardInfo>(eTableName.identitycard, number);
                text.text = string.Format("{0}", info.address);
            }
        }

    }

    string GetSearchNumber(int count)
    {
        string number = input.text;
        if (number.Length >= count)
        {
            number = number.Substring(0, count);
        }
        else
        {
            text.text = string.Format("输入号码不足{0}位", count);
            return string.Empty;
        }
        return number;
    }

    public void OnClickTestStreamReader()
    {
        float time = Time.realtimeSinceStartup;
        if (mDict == null)
        {
            string path = Application.dataPath + "/phone.csv";
            StreamReader sr = new StreamReader(path);
            string line = string.Empty;
            mDict = new Dictionary<string, string[]>();
            while ((line = sr.ReadLine()) != null)
            {
                if (!string.IsNullOrEmpty(line))
                {
                    string[] str = line.Split(',');
                    mDict.Add(str[1].Trim(), str);
                }
            }
            sr.Close();
            Debug.LogFormat("read time={0}s", Time.realtimeSinceStartup - time);
        }
        time = Time.realtimeSinceStartup;
        string number = GetSearchNumber(7);
        foreach(var item in mDict)
        {
            if (item.Key == number)
            {
                text.text = string.Format("{0} {1}", item.Value[2], item.Value[3]);
                break;
            }
        }
        Debug.LogFormat("search time={0}s", Time.realtimeSinceStartup - time);
    }

}


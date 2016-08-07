using UnityEngine;
using System.Collections;
using UnityEngine.UI;


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

    public void ClickButton()
    {
        mIndex = dropdown.value;
        if (mIndex == 0)
        {
            string number = GetSearchNumber(7);
            if (!string.IsNullOrEmpty(number))
            {
                PhoneInfo phoneinfo = TableManager.Instance.GetTableData<PhoneInfo>(eTableName.phonenumber, number);
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

}


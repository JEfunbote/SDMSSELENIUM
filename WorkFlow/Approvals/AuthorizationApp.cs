using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace WorkFlow.Reviews.Approvals;

public class AuthorizationApp
{
	private readonly IWebDriver _webDriver;

	public AuthorizationApp(IWebDriver webDriver)
	{
		_webDriver = webDriver;

	}


    public IWebElement dropDownCat
    {
        get
        {
            var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
			return wait.Until(ExpectedConditions.ElementIsVisible(By.Id("ItemCategory")));
        }
    }

    public IWebElement dropDownType
    {
        get
        {
            var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            return wait.Until(ExpectedConditions.ElementIsVisible(By.Id("ItemType")));
        }
    }
    public IWebElement btnSearch
    {
        get
        {
            var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            return wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div.col-sm-1 a.item-button")));
        }
    }

    public IWebElement tblResult
    {
        get
        {
            var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            return wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("table.table-hover")));
        }
    }
    public IList<IWebElement> rows => tblResult.FindElements(By.CssSelector("tbody tr"));

    public IWebElement btnReqInfo
    {
        get
        {
            var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            return wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(text(), 'Request Information')]")));
        }
    }
    public IWebElement btnRevInfo => _webDriver.FindElement(By.CssSelector("a[title='Review Item']"));
	public IWebElement txtRevComment => _webDriver.FindElement(By.Id("txtComment"));
	public IWebElement rdBtnApprove => _webDriver.FindElement(By.CssSelector("input[type='radio'][value='1'][name='rbAuthStatus']"));
	public IWebElement rdBtnDecline => _webDriver.FindElement(By.CssSelector("input[type='radio'][value='-1'][name='rbAuthStatus']"));
	public IWebElement btnSubmit => _webDriver.FindElement(By.Id("btnSave"));
	public IWebElement btnClose => _webDriver.FindElement(By.CssSelector("button.btn.btn-secondary[data-dismiss='modal']"));
	//public IWebElement btnClickOk => _webDriver.FindElement(By.CssSelector("button.confirm[style*='display: inline-block;'][style*='background-color: rgb(140, 212, 245);']"));

    public IWebElement btnClickOk
    {
        get
        {
            var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            return wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("button.confirm[style*='display: inline-block;'][style*='background-color: rgb(140, 212, 245);']")));
        }
    }
    public void EnterRevComment(string comment)
	{
		txtRevComment.SendKeys(comment);
	}
	public void ClickSubmit()
	{
		btnSubmit.Clicks();
	}
	public void ClickOk()
	{
		btnClickOk.Clicks();
	}


}
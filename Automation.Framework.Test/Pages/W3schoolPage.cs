using Automation.Framework.Base;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Automation.Framework.Test.Pages
{
    class W3schoolPage : BasePage
    {
        public W3schoolPage(IWebDriver driver) : base(driver)
        {
        }
        public string tryItUrSelfPageUrl = "https://www.w3schools.com/tags/tryit.asp?filename=tryhtml_button_test";
        public IWebElement TryItURselfButtonWebElement => WaitTillElementExist("//div[@id='main']//a[@href='tryit.asp?filename=tryhtml_button_test']");

        public string tryItUrSelfCheckboxUrl = "https://www.w3schools.com/tags/att_input_type_checkbox.asp";

        public string tryItUrSelfBrowserUrl = "https://www.w3schools.com/jsref/met_win_open.asp";

        public string w3schoolHtmlDemoUrl = "https://www.w3schools.com/html/default.asp";

        public string w3schoolComboboxUrl = "https://www.w3schools.com/tags/tag_select.asp";

        public string w3schoolPopUpUrl = "https://www.w3schools.com/js/js_popup.asp";

        public string w3schoolLabelUrl = "https://www.w3schools.com/tags/tryit.asp?filename=tryhtml_label";

        public string w3schoolLinkUrl = "https://www.w3schools.com/html/tryit.asp?filename=tryhtml_links_w3schools";

        public string w3schoolRadioButtonUrl = "https://www.w3schools.com/tags/tryit.asp?filename=tryhtml5_input_type_radio";

        public string w3schoolTextBoxUrl = "https://www.w3schools.com/tags/tryit.asp?filename=tryhtml_form_submit";

        public string w3schoolMouseActionUrl = "http://demos.telerik.com/kendo-ui/dragdrop/events";

        public IWebElement firstNameTextboxWebelement => WaitTillElementDisplayed("//form[@action='/action_page.php']/input[@name='FirstName']");

        public IWebElement lastNameTextboxWebelement => WaitTillElementDisplayed("//form[@action='/action_page.php']/input[@name='LastName']");

        public IWebElement textBoxSubmitWebElement => WaitTillElementDisplayed("//form[@action='/action_page.php']/input[@value='Submit']");

        public IWebElement textboxResultWebElement => WaitTillElementDisplayed("//body[@class='w3-container']/div[1]");

        public IWebElement radioButtonSubmitWebelement => WaitTillElementExist("//form[@action='/action_page.php']/input[@value='Submit']");

        public IWebElement radioButtonResulttxtWebElement => WaitTillElementExist("//body[@class='w3-container']/div[1]");

        public IWebElement FemaleRadioButtonWebElement => WaitTillElementDisplayed("//form[@action='/action_page.php']/input[2]");

        public IWebElement Age30RadioButtonWebElement => WaitTillElementDisplayed("//form[@action='/action_page.php']/input[4]");

        public IWebElement titleAferLinkCLickedWebElement => WaitTillElementDisplayed("/html/body/div[1]/a[@href='//www.w3schools.com']");

        public IWebElement linkWebElement => WaitTillElementExist("//body//a[@href='https://www.w3schools.com/html/']");

        public IWebElement OtherLabelwebElement => WaitTillElementExist("//form[@action='/action_page.php']/label[.='Other']");

        public IWebElement OtherLabelChkWebElement => WaitTillElementExist("/html//input[@id='other']");

        public IWebElement popUpPromptResultWebElement => WaitTillElementDisplayed("/html//p[@id='demo']");

        public IWebElement popUPResultWebElement => WaitTillElementDisplayed("/html//p[@id='demo']");

        public IWebElement TryItURselfPopUpButtonWebElement => WaitTillElementDisplayed("/html[1]/body[1]/div[6]/div[1]/div[1]/div[6]/a[1]");

        public IWebElement TryItURselfPopUpPromptButtonWebElement => WaitTillElementDisplayed("/html[1]/body[1]/div[6]/div[1]/div[1]/div[9]/a[1]");

        public IWebElement comoboBoxWebElement => WaitTillElementDisplayed("//body/select");

        public IWebElement TryItURselfComboBoxButtonWebElement => WaitTillElementDisplayed("//div[@id='main']//a[@href='tryit.asp?filename=tryhtml_select']");

        public IWebElement NextButtonWebElement => WaitTillElementDisplayed("//div[@id='main']/div[2]/a[@href='html_intro.asp']");

        public IWebElement PreviousButtonWebElement => WaitTillElementDisplayed("//div[@id='main']/div[2]/a[@href='default.asp']");
        public IWebElement TryItURselfcheckboxButtonWebElement => WaitTillElementExist("//div[@id='main']//a[@href='tryit.asp?filename=tryhtml5_input_type_checkbox']");

        public IWebElement RunButtonWebElement => WaitTillElementExist("/html//div[@class='w3-bar']/button[.='Run »']");

        public IWebElement checkboxCarWebElement => WaitTillElementExist("//form[@action='/action_page.php']/input[@name='vehicle2']");

        public IWebElement demoFrameWebElement => WaitTillElementExist("/html//iframe[@id='iframeResult']");

        public IWebElement submitButtonWebelement => WaitTillElementExist("//form[@action='/action_page.php']/input[@value='Submit']");

        public IWebElement checkboxResultWebElement => WaitTillElementExist("//body[@class='w3-container']/div[1]");

        public IWebElement TryItURselfBrowserButtonWebElement => WaitTillElementDisplayed("//div[@id='main']//a[@href='tryit.asp?filename=tryjsref_win_open']");

        public IWebElement tryItButtonWebElement => WaitTillElementDisplayed("//body/button[.='Try it']");


    }
}

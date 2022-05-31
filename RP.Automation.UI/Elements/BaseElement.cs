using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;

namespace RP.Automation.UI.Elements
{
    public abstract class BaseElement : IWrapsElement, IWebElement
    {
        private IWebElement _wrappedElement;
        public IWebElement WrappedElement => throw new NotImplementedException();

        private string name;

        protected BaseElement(IWebElement wrappedElement)
        {
            _wrappedElement = wrappedElement;
        }

        public string GetName()
        {
            return name;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public string ToString()
        {
            return name;
        }

        public IWebElement GetWrappedElement
        {
            get
            {
                return _wrappedElement;
            }
        }

        public string TagName { get { return GetWrappedElement.TagName; } }
        public bool Enabled { get { return GetWrappedElement.Enabled; } }
        public bool Selected { get { return GetWrappedElement.Selected; } }
        public Point Location { get { return GetWrappedElement.Location; } }
        public Size Size { get { return GetWrappedElement.Size; } }
        public bool Displayed { get { return GetWrappedElement.Displayed; } }
        public string Text { get { return GetWrappedElement.Text; } }
              

        public ISearchContext GetShadowRoot()
        {
            return GetWrappedElement.GetShadowRoot();
        }

        public string GetCssValue(string propertyName)
        {
            return GetWrappedElement.GetCssValue(propertyName);
        }

        public string GetProperty(string propertyName)
        {
            return GetWrappedElement.GetProperty(propertyName);
        }

        public string GetDomProperty(string propertyName)
        {
            return GetWrappedElement.GetDomProperty(propertyName);
        }

        public string GetDomAttribute(string attributeName)
        {
            return GetWrappedElement.GetDomAttribute(attributeName);
        }

        public string GetAttribute(string name)
        {
            return GetWrappedElement.GetAttribute(name);
        }        

        public void Click()
        {
            GetWrappedElement.Click();
        }

        public void Submit()
        {
            GetWrappedElement.Submit();
        }

        public void SendKeys(string text)
        {
            GetWrappedElement.SendKeys(text);
        }

        public void Clear()
        {
            GetWrappedElement.Clear();
        }

        public IWebElement FindElement(By by)
        {
            return GetWrappedElement.FindElement(by);
        }

        public List<IWebElement> FindElements(By by)
        {
            return GetWrappedElement.FindElements(by).ToList();
        }

        ReadOnlyCollection<IWebElement> ISearchContext.FindElements(By by)
        {
            throw new NotImplementedException();
        }      
    }
}


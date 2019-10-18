using OpenQA.Selenium;

namespace SpringCM.Automation.PageObjects
{
    public static class ExpectedConditions
    {
        /// <summary>
        /// Checks whether an element is present on the DOM of a page and is visible.
        /// </summary>
        /// <param name="locator">The locator used to find the element.</param>
        /// <returns>The <see cref="IWebElement"/> once it is located and visible.</returns>
        public static System.Func<IWebDriver, IWebElement> ElementIsVisible(By locator)
        {
            return (driver) =>
            {
                try
                {
                    var element = driver.FindElement(locator);
                    return element.Displayed ? element : null;
                }
                catch (StaleElementReferenceException)
                {
                    return null;
                }
                catch (NoSuchElementException)
                {
                    return null;
                }
            };
        }

        /// <summary>
        /// Checks whether an element is clickable.
        /// </summary>
        /// <param name="locator">The locator used to find the element.</param>
        /// <returns>The <see cref="IWebElement"/> once it is located and clickable.</returns>
        public static System.Func<IWebDriver, IWebElement> ElementIsClickable(By locator)
        {
            return (driver) =>
            {
                var element = driver.FindElement(locator);
                try
                {
                    if (element != null && element.Displayed && element.Enabled)
                    {
                        return element;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (StaleElementReferenceException)
                {
                    return null;
                }
            };
        }

        /// <summary>
        /// Checks whether an element is invisible or not present on DOM
        /// </summary>
        /// <param name="locator"></param>
        /// <returns><see langword="true"/> if the element is not displayed; otherwise, <see langword="false"/>.</returns>
        public static System.Func<IWebDriver, bool> InvisibilityOfElementLocated(By locator)
        {
            return (driver) =>
            {
                try
                {
                    var element = driver.FindElement(locator);
                    return !element.Displayed;
                }
                catch (NoSuchElementException)
                {
                    return true;
                }
                catch (StaleElementReferenceException)
                {
                    return true;
                }
                catch (WebDriverTimeoutException)
                {
                    return true;
                }
            };
        }
    }
}
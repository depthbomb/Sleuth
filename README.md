# Sleuth

This is a "bot" I made for automatically playing [Reddit's new Imposter event.](http://reddit.com/r/imposter)

The bot uses [Selenium](https://www.selenium.dev/) to automate actions within a browser of your (currently limited) choice!

The bot works by first logging you in<sup>1</sup> and then always voting for the first answer when provided with the choices. __Make sure you have already submitted your answer for Imposter as the bot assumes you have already answered__.

## Drivers

In order to use the bot, you must download a web driver depending on your browser. Sleuth currently supports 3 major browsers: **Google Chrome**, **Firefox**, and **Opera** (untested).

You can find links to the individual web drivers below:

| Browser | Web Driver Download URL                   |
|---------------|---------------------------------------------------------------|
| Google Chrome | https://chromedriver.chromium.org/downloads                   |
| Firefox       | https://github.com/mozilla/geckodriver/releases               |
| Opera         | https://github.com/operasoftware/operachromiumdriver/releases |

## Settings

Your settings file contains three properties: _Username_, _Password_, and _Browser_.

* Username and Password are your Reddit credentials (or the credentials to an account you wish to use with Sleuth).
* Browser refers to which web driver you wish to use.
  * Supports the values: `chrome`, `firefox`, `ff`, `opera`
  * You will need a browser installed if you wish to use it with Sleuth.

## Installation

Download [one of the releases](https://github.com/depthbomb/Sleuth/releases/latest) and extract all of the files to a folder of your choosing. Next, download one of the web drivers (above) that correspond to your favorite browser and place that `.exe` into the same folder in which you extracted Sleuth's files to.

## Other requirements

You will need [.NET Framework 4.6](https://www.microsoft.com/en-us/download/details.aspx?id=48130) or higher installed.

---

<sup>1</sup> Yes, the program does require your Reddit username and password. However I assure you that we won't send it to a super shady server so we can see your boring posts and comments.
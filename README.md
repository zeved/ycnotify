# ycnotify
Hacker News notification tool
=============================

Simple program I wrote with the idea of learning more C#.

Functionality:
  - periodically (the interval can be set by the user) scans https://news.ycombinator.com/newest for new links
  - checks if there are new ones compared to the old scan and replaces them accordingly
  - stays in the tray and notifies the user with a baloon when new links are available
  - displays the links in a simple window

Feature: ReportPortal

Tests for widgets

Background: 
   Given the user opened home page
     And sucessfully logged in
     And added new dashboard

@tag1
Scenario Outline: Add a new widget
   When the user add new widget <widget type>
   Then the widget should be added to the list

Examples:
| widget type             |
| Launch statistics chart |
| Overall statistics      |
| Launches duration chart |

Scenario: Add a new widget with different options
When the user add new widget
| N | ChartType               |
| 1 | Launch statistics chart |
| 2 | Overall statistics      |
| 3 | Launches duration chart |
Then the widget should be added to the list

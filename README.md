# Introduction
This is a test automation framework to be used as a base for creating a test automation solution.  This framework can be used as a base for UI and API automated tests.

# Getting Started
1.	Installation process:
    - Install Git Bash on your laptop.  It is available in the Software Center.
    - Clone the SogetiTestAutomation master branch from VSTS to your local computer.  You can use Visual Studio.
    - Open Git Bash.
        a.  Navigate to the SogetiTestAutomation location.
        b.	Enter: $ git remote set-url origin https://{VSTS}.visualstudio.com/_git/{VSTS project}
        c.	Enter: $ git push –u origin master
                    
    - Go to your VSTS project and verify the SogetiTestSolution solution is in your VSTS project.
 
2.	Software dependencies:
    - MSDN license for Visual Studio
3.	Latest releases
    - Release 1.0:
        a. Created basic folder stucture.
        b. Soft Asserts.
        c. RestSharp reference.
        d. Web Driver reference.
4.	

# Build and Test
1.  Use Visual Studio to build the solution with your application projects.
2.  Use Nunit in your application automated tests.  The tests can be used running Visual Studio.
3.  The results will be displayed in a dashboard widget. 

# Contribute
1.  If you want to Contribute please create a branch with your changes and create a pull request.  
    Please add the following reviewers to your pull request:
        - Jeffrey.Bertram@us.sogeti.com
        - Chris.Macgowan@us.sogeti.com
        - Igor.Khorev@us.sogeti.com
        - Albert.Arulanandasamy@us.sogeti.com



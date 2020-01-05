using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

    public Text text;
    private enum States {
        title, intro, intro_0 , shower, change, eat, leave, leave_0, swerve, swerve_0, no_state
    };
    private States curState;
    private States prevState;
    private States prevPrevState;

	// Use this for initialization
	void Start () {
        prevPrevState = States.no_state;
        curState = States.title;
	}
	
	// Update is called once per frame
	void Update () {
        if (curState == States.title)
        {
            prevState = curState;
            state_title();
        }
        else if (curState == States.intro) { state_intro(); }
        else if (curState == States.intro_0){ state_intro_0(); }
        else if (curState == States.shower) { state_shower(); }
        else if (curState == States.change) { state_change(); }
        else if (curState == States.eat) { state_eat(); }
        else if (curState == States.leave) { state_leave(); }
        else if (curState == States.leave_0) { state_leave_0(); }
        else if (curState == States.swerve) { state_swerve(); }
        else if (curState == States.swerve_0) { state_swerve_0(); }
	}

    void state_title()
    {
        text.text = "Press the Space Key to Begin";
        if (Input.GetKeyDown(KeyCode.Space) && prevState == States.title)
        {
            curState = States.intro;
        }
    }

    void state_intro()
    {
        text.text = "You awake with a start. \"Was that really a dream?\" " +
                    "You think to yourself, reflecting on the events of the " +
                    "previous night. Everything seems to be a blur. " +
                    "You slowly turn towards your alarm clock to check the time. " +
                    "Your eyes strain to read the display, but you can just make " +
                    "out the time, 4:30AM. \"SHIT! I\'M GOING TO BE LATE FOR  " +
                    "WORK!\" You exclaim as you throw the sheets off of you.\n\n" +
                    "Press Space to continue...";
        if (Input.GetKeyDown(KeyCode.Space) && prevState == States.title)
        {
            curState = States.intro_0;
            prevState = States.intro;
        }
    }

    void state_intro_0()
    {
        text.text = "\"I have to be to work in 1 hour and I still need to eat, shower, and change. " +
                    "Do I even have time for all of that?\" You think to yourself.\n\n" +
                    "Press S to Shower\nPress C to Change clothes\nPress E to Eat breakfast";

        prevState = States.intro_0;
        if (Input.GetKeyDown(KeyCode.S))
        {
            curState = States.shower;
        } else if (Input.GetKeyDown(KeyCode.C))
        {
            curState = States.change;
        } else if (Input.GetKeyDown(KeyCode.E))
        {
            curState = States.eat;
        }
    }

    void state_shower()
    {
        if(prevState == States.intro_0)
        {
            text.text = "You hurridly take a cold shower. \"Christ that was cold,\" you think to yourself. " + 
                        "You look at the clock. The time reads 4:35AM. \"Shit! I still need to get dressed.\"\n\n" +
                        "Press C to change your clothes";
        } else if(prevState == States.eat)
        {
            text.text = "You hurridly take a cold shower. \"Christ that was cold,\" you think to yourself. " +
                        "You look at the clock. The time reads 4:45AM. \"Shit! I still need to get dressed.\"\n\n" +
                        "Press C to change your clothes";
            prevPrevState = States.eat;
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            prevState = States.shower;
            curState = States.change;
        }
        
    }

    void state_change()
    {
        if ((prevState == States.shower || prevState == States.intro_0) && prevPrevState == States.no_state)
        {
            text.text = "You run to the closest and shuffle through. You have some difficulty finding some decent clothes to wear. " + 
                        "After a few minutes you find a decent shirt and set of khakis.\n\n" + 
                        "Press E to Eat breakfast or L to Leave for work";
            if (Input.GetKeyDown(KeyCode.L))
            {
                prevState = States.change;
                curState = States.leave;
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                prevState = States.change;
                curState = States.eat;
            }
        }
        else if (prevState == States.eat || (prevState == States.shower && prevPrevState == States.eat))
        {
            text.text = "You run to the closest and shuffle through. You have some difficulty finding some decent clothes to wear. " +
                        "After a few minutes you find a decent shirt and set of khakis.\n\n" +
                        "Press L to Leave for work";
            
            if (Input.GetKeyDown(KeyCode.L))
            {
                prevState = States.change;
                curState = States.leave;
            }
        }
    }

    void state_eat()
    {
        if(prevState == States.intro_0)
        {
            text.text = "You hastily eat a breakfast of grits and scrambled eggs. You had turned on the TV while cooking, " +
                        "but it was mostly boring news reports. The only thing that interested you was a blurb about some murders " +
                        "that had taken place on the previous evening.\n\n" + 
                        "Press S to Shower or C to Change";
            if (Input.GetKeyDown(KeyCode.S))
            {
                prevState = States.eat;
                curState = States.shower;
            }
            else if (Input.GetKeyDown(KeyCode.C))
            {
                prevState = States.eat;
                curState = States.change;
            }
        } else if(prevState == States.change)
        {
            text.text = "You hastily eat a breakfast of grits and scrambled eggs. You had turned on the TV while cooking, " +
                        "but it was mostly boring news reports. The only thing that interested you was a blurb about some murders " +
                        "that had taken place on the previous evening.\n\n" +
                        "Press L to Leave for work";
            if (Input.GetKeyDown(KeyCode.L))
            {
                prevState = States.eat;
                curState = States.leave;
            }
        }
    }

    void state_leave()
    {
        if(prevState == States.change || prevState == States.eat)
        {
            text.text = "You blearily stumble towards the front door; reaching for the knob, you realize " +
                        "that you have forgotten to grab your keys and lunch. It takes you some time to find your keys and " +
                        "quickly pack a small lunch. You leave your house at 5:00AM. During the drive you struggle " +
                        "piece together the events from the night before. It all seems so blurry. You remember a lot " +
                        "of screaming, or was it cheering? It's all just so hard to comprehend.\n\n" +
                        "Press Space to continue...";
            if (Input.GetKeyDown(KeyCode.Space))
            {
                prevState = States.leave;
                curState = States.leave_0;
            }
        }
    }

    void state_leave_0()
    {
        text.text = "You can still picture the faces of your coworkers. Their eyes and jaws wide open " +
                    "in an expression of shock or horror. Suddenly you see something in the road ahead.\n\n" +
                    "Press S to Swerve";
        if (Input.GetKeyDown(KeyCode.S))
        {
            prevState = States.leave_0;
            curState = States.swerve;
        }
    }

    void state_swerve()
    {
        text.text = "You swerve to avoid the obstacle. In your panic you hit a bump and your car is thrust into the air. " +
                    "Everything seems to be going in slow motion. You feel a sudden jolt as the car crushes in around you. " +
                    "Everything goes black.\n\n" +
                    "Press Space to continue...";
        if (Input.GetKeyDown(KeyCode.Space))
        {
            prevState = States.swerve;
            curState = States.swerve_0;
        }
    }

    void state_swerve_0()
    {
        text.text = "You blink your eyes slowly as you awake. Your head is pounding, is that wet feeling blood or sweat? " +
                    "You try to look around, but you can only make out a shadow moving towards you. What is it or better, who is it?" +
                    "As the shadow draws closer you suddenly remember what had happened last night. As the person leans in you begin to " +
                    "panic. \"Don\'t worry,\" says the figure as it draws a knife, \"This hurts me more than it hurts you.\"\n\n" +
                    "Press Return to play again";
        if (Input.GetKeyDown(KeyCode.Return))
        {
            prevState = States.swerve_0;
            prevPrevState = States.no_state;
            curState = States.title;
        }
    }
}

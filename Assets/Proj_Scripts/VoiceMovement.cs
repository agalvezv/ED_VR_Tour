using System;
using System.Linq;                  //ToArray function
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using UnityEditor;
using System.Xml.Serialization;
using UnityEngine.SceneManagement;

public class VoiceMovement : MonoBehaviour
{
    string on = "Main Menu";
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();
    
    private void Start()
    {
        //actions.Add("forward", Forward);
        //actions.Add("up", Up);
        //actions.Add("down", Down);
        //actions.Add("back", Back);

        actions.Add("menu", Main);
        actions.Add("options", Options);
        actions.Add("modes", Modes);
        actions.Add("controls", Controls);
        actions.Add("audio", Audio);
        actions.Add("display", Display);
        actions.Add("play", Play);
        actions.Add("close", Play);
        actions.Add("quit", Quit);
        actions.Add("pause", Main);

        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;           //when event triggers, call RecognizedSpeech
        keywordRecognizer.Start();          //start listening for voice
        //keywordRecognizer.Stop();
    }

    //upon recognition of speech, do the following
    private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);     //dospplay the text that was recognized
        actions[speech.text].Invoke();       //perform action based on key txt recognized

    }

    //GameObject[] menus = new GameObject[] { }; 
    //menus[0] = GameObject.Find("Background");
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public GameObject modesMenu;
    public GameObject controlsMenu;
    public GameObject audioMenu;
    public GameObject displayMenu;
    public GameObject background;
    public GameObject loadingScreen;

    public void voice(string selection)
    {
        //string menu = "Main Menu", options = "Options Menu", modes = "Modes Menu",
        //    controls = "Controls Menu", audio = "Audio Menu", display = "Display Menu";
        if (mainMenu.activeSelf) mainMenu.SetActive(false);
        if (optionsMenu.activeSelf) optionsMenu.SetActive(false);
        if (modesMenu.activeSelf) modesMenu.SetActive(false);
        if (controlsMenu.activeSelf) controlsMenu.SetActive(false);
        if (audioMenu.activeSelf) audioMenu.SetActive(false);
        if (displayMenu.activeSelf) displayMenu.SetActive(false);
        
        if (selection == "play" || selection == "quit" || selection == "close" || selection == "")
        { background.SetActive(false); loadingScreen.SetActive(true); }
        else { background.SetActive(true); loadingScreen.SetActive(false); }

        if (selection == "menu") { mainMenu.SetActive(true); }
        if (selection == "options") { optionsMenu.SetActive(true); }
        if (selection == "modes") { modesMenu.SetActive(true); }
        if (selection == "controls") { controlsMenu.SetActive(true); }
        if (selection == "audio") { audioMenu.SetActive(true); }
        if (selection == "display") { displayMenu.SetActive(true); }
        
        //else { Debug.Log(selection); GameObject.Find(selection).SetActive(true); }
    }
    //private void Forward()
    //{
    //    //Debug.Log("Woah"); -> function is being called, but not transforming 
    //    transform.Translate(10, 0, 0);
    //}
    //private void Back()
    //{
    //    transform.Translate(-10, 0, 0);
    //}
    //private void Up()
    //{
    //    //Canvas canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
    //    //Canvas canvas2 = GameObject.Find("Canvas");
    //    //canvas.SetActive(true);
    //    transform.Translate(0, 10, 0);
    //}
    //private void Down()
    //{
    //    transform.Translate(0, -10, 0);
    //}
    private void Main()
    {
        string selection = "menu";
        voice(selection);
    }
    private void Options()
    {
        string selection = "options";
        voice(selection);
    }
    private void Modes()
    {
        string selection = "modes";
        voice(selection);
    }
    private void Controls()
    {
        string selection = "controls";
        voice(selection);
    }
    private void Audio()
    {
        string selection = "audio";
        voice(selection);
    }
    private void Display()
    {
        string selection = "display";
        voice(selection);
    }
    private void Play()
    {
        //load next scene in queue
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        voice("play");
    }
    private void Quit()
    {
        Debug.Log("QUIT!"); //indicator that it worked
        voice("quit");
        Application.Quit(); //close the program
    }

}

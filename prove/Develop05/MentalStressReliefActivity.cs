// This class, MentalStressReliefActivity, was added as part of the Creativity section requirements.
// It introduces a new activity focused on helping users relieve mental stress through guided steps.
public class MentalStressReliefActivity : Activity {
    
    private List<string> _steps = new List<string> {
        "Breathe in deeply, hold it briefly...",
        "Breathe out slowly, feeling tension ease with each exhale...",
        "Picture your stressful thoughts drifting away and fading...",
        "Let go of any worries, allowing your mind to feel lighter...",
        "Embrace the calm and open space you've created within yourself."
    };
    public MentalStressReliefActivity(int duration) : base("Mental Stress Relief","This activity will guide you through a series of steps to help release mental stress and find calm.", duration) {}

    public void Start()
    {
        DisplayStartingMessage();
        
        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());
        while (DateTime.Now < endTime)
        {
            ShowCountDown(3);
            
            Console.WriteLine("> " + _steps[new Random().Next(_steps.Count)]);
            ShowSpinner(3);
        }

        DisplayEndingMessage();
    }

}
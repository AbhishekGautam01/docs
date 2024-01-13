import "bulma/css/bulma.css";
import ProfileCard from "./ProfileCard";
import AlexaImage from "./images/alexa.png";
import GoogleImage from "./images/cortana.png";
import SiriImage from "./images/siri.png";

function App() {
  return (
    <div>
      <div>Personal Digital Assistants</div>
      <div className="container">
        <div className="section">
          <div className="columns">
            <div className="column is-4">
              <ProfileCard title="Siri" handle="@apple3000" image={SiriImage} />
            </div>
            <div className="column is-4">
              <ProfileCard title="Alexa" handle="@alexa99" image={AlexaImage} />
            </div>
            <div className="column is-4">
              <ProfileCard
                title="Google"
                handle="@google"
                image={GoogleImage}
              />
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}

export default App;

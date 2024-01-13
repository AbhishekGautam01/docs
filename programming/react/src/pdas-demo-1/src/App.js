import "bulma/css/bulma.css";
import ProfileCard from "./ProfileCard";
import AlexaImage from "./images/alexa.png";
import GoogleImage from "./images/cortana.png";
import SiriImage from "./images/siri.png";

function App() {
  return (
    <div>
      <section className="hero is-primary">
        <div className="hero-body">
          <p className="title">Personal Digital Assistants</p>
        </div>
      </section>
      <div className="container">
        <div className="section">
          <div className="columns">
            <div className="column is-4">
              <ProfileCard
                title="Siri"
                handle="@apple3000"
                image={SiriImage}
                description="Created by Apple"
              />
            </div>
            <div className="column is-4">
              <ProfileCard
                title="Alexa"
                handle="@alexa99"
                image={AlexaImage}
                description="created by Amazon"
              />
            </div>
            <div className="column is-4">
              <ProfileCard
                title="Google"
                handle="@google"
                image={GoogleImage}
                description="created by google"
              />
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}

export default App;

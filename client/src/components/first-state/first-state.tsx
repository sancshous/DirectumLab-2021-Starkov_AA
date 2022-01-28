import * as React from "react";
import Header from "../header/header";
import Footer from "../footer/footer";
import StoryPlaceHolder from "./story-placeholder/story-placeholder";
import Players from "../players/players";
import "./first-state.css";

const FirstState: React.FC = () => {
  return <div className={'body'}>
    <Header user={{name: 'Dima'}} />
    <main className="main">
      <div className="container main__content">
        <StoryPlaceHolder />
        <Players className={'story'} input={'go'} />
      </div>
    </main>

    <Footer />
  </div>
    ;
}

export default FirstState;

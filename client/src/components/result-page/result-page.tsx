import * as React from "react";
import Header from "../header/header";
import Footer from "../footer/footer";
import History from "../history/history";
import Players from "../players/players";
import VoteResultContainer from "./vote-result-container/vote-result-container";

const ResultPage: React.FC = () => {
  return <div className={'body'}>
    <Header user={{name: 'Dima'}} />
    <main className="main">
      <div className="container main__content story">
        <div className="content">
          <p className="Story">Story</p>
          <VoteResultContainer />
          <History />
        </div>
        <Players className={''} input={'go'} />
      </div>
    </main>

    <Footer />
  </div>
    ;
}

export default ResultPage;

import * as React from "react";
import Header from "../header/header";
import Footer from "../footer/footer";
import History from "../history/history";
import Players from "../players/players";
import CardGroup from "./card-group/card-group";

const PlaningPage: React.FC = () => {
  return <div className={'body'}>
    <Header user={{name: 'Dima'}} />
    <main className="main">
      <div className="container main__content story">
        <div className="content">
          <p className="Story">Story</p>
          <CardGroup card={''} />
          <History defaultState={false} />
        </div>
        <Players className={''} input={'finish'} />
      </div>
    </main>

    <Footer />
  </div>
    ;
}

export default PlaningPage;

import * as React from "react";
import Header from "../header/header";
import Footer from "../footer/footer";
import './no-match-page.css';

const NoMatchPage: React.FC = () => {
  return <div className={'body'}>
    <Header user={null} />
    <main className="main">
      <div className="container main__content">
        <h2 className={'nomatchPage'}>Ooops!!</h2>
      </div>
    </main>

    <Footer />
  </div>
    ;
}

export default NoMatchPage;

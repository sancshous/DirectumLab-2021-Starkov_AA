import * as React from "react";
import Header from "../header/header";
import Footer from "../footer/footer";
import Form from "./form/form";

interface IProps {
  form: string
}

const LoginPage: React.FC<IProps> = (props) => {
  function RenderForm(){
    switch (props.form) {
      case 'form-create':
        return <Form loginPage={'create'} />
      case 'form-invite':
        return <Form loginPage={'invite'} />
    }
  }
  return <div className={'body'}>
    <Header user={null} />
    <main className="main">
      <div className="container main__content">
        {
          RenderForm()
        }
      </div>
    </main>

    <Footer />
  </div>
    ;
}

export default LoginPage;

import * as React from 'react';
import Footer from '../footer/footer';
import Header from '../header/header';
import './error-page.css';

const ErrorPage: React.FC = () => {
  return (
    <div className='ErrorPage'>
      <Header />
      <div className='oops'>
        <p className='text'>Error...</p>
      </div>
      <Footer />
    </div>
  );
};

export default ErrorPage;

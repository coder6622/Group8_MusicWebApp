import React from 'react';
import Sidebar from '../components/Sidebar/Sidebar';
import classNames from 'classnames/bind';
import styles from './DefaultLayout.module.scss';

const cx = classNames.bind(styles);
function DefaultLayout({ children }) {
  return (
    <div className={cx(['main-body'], 'row ms-0')}>
      <div className={cx([], 'col-1 d-flex justify-content-center')}>
        <Sidebar />
      </div>
      <div className={cx([], 'bg-light col-11')}>{children}</div>
    </div>
  );
}

export default DefaultLayout;

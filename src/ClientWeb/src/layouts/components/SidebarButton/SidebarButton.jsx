import React from 'react';
import { IconContext } from 'react-icons';
import { Link, useLocation } from 'react-router-dom';
import classNames from 'classnames/bind';
import styles from './SidebarButton.module.scss';

const cx = classNames.bind(styles);

function SidebarButton(props) {
  const location = useLocation();

  const isActive = location.pathname === props.to;

  return (
    <Link
      to={props.to}
      className={cx('text-decoration-none')}
    >
      <div
        className={cx(['btn-body'], `${isActive ? 'active' : ''}`, 'p-3 mx-1')}
      >
        <IconContext.Provider value={{ size: '24px' }}>
          {props.icon}
          <p className={cx('btn-title')}>{props.title}</p>
        </IconContext.Provider>
      </div>
    </Link>
  );
}

export default SidebarButton;

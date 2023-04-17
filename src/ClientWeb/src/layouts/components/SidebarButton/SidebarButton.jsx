import React from 'react';
import { IconContext } from 'react-icons';
import { Link, useLocation } from 'react-router-dom';

function SidebarButton(props) {
  const location = useLocation();

  const isActive = location.pathname === props.to;

  return (
    <Link
      to={props.to}
      className='no-underline'
    >
      <div
        className={`transition-transform text-accent px-3 py-4 mx-1 flex rounded-3xl items-center justify-center flex-col hover:text-white ${
          isActive ? 'bg-active text-white scale-105' : ''
        }`}
      >
        <IconContext.Provider value={{ size: '24px' }}>
          {props.icon}
          <p className='mx-1 font-semibold text-sm'>{props.title}</p>
        </IconContext.Provider>
      </div>
    </Link>
  );
}

export default SidebarButton;

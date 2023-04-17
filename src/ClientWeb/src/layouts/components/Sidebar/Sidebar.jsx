import React from 'react';
import SidebarButton from '../SidebarButton/SidebarButton';
import { MdFavorite } from 'react-icons/md';
import { FaGripfire, FaPlay } from 'react-icons/fa';
import { FaSignOutAlt } from 'react-icons/fa';
import { IoLibrary } from 'react-icons/io5';
import { MdSpaceDashboard } from 'react-icons/md';

import config from '../../../config';
import { images } from '../../../assets';

function Sidebar(props) {
  const { isFullHeight } = props;
  console.log(isFullHeight);
  return (
    <div
      className={`flex flex-col items-center justify-between gap-9 bg-primary ${
        isFullHeight ? 'h-screen' : `h-[calc(100vh-var(--player-height))]`
      }`}
    >
      <img
        src={images.user_default}
        className='rounded-full w-16 h-16 mt-5'
        alt='profile'
      />
      <div className=''>
        <SidebarButton
          title='Feed'
          to={config.routes.feed}
          icon={<MdSpaceDashboard />}
        />
        <SidebarButton
          title='Trending'
          to={config.routes.trending}
          icon={<FaGripfire />}
        />
        <SidebarButton
          title='Player'
          to={config.routes.player}
          icon={<FaPlay />}
        />
        <SidebarButton
          title='Favorites'
          to={config.routes.favorites}
          icon={<MdFavorite />}
        />
        <SidebarButton
          title='Playlist'
          to={config.routes.playlist}
          icon={<IoLibrary />}
        />
      </div>
      <SidebarButton
        title='Sign Out'
        to=''
        icon={<FaSignOutAlt />}
      />
    </div>
  );
}

export default Sidebar;

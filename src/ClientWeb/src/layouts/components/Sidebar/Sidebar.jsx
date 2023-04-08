import React from 'react';
import SidebarButton from '../SidebarButton/SidebarButton';
import { MdFavorite } from 'react-icons/md';
import { FaGripfire, FaPlay } from 'react-icons/fa';
import { FaSignOutAlt } from 'react-icons/fa';
import { IoLibrary } from 'react-icons/io5';
import { MdSpaceDashboard } from 'react-icons/md';

import config from '../../../config';
import { images } from '../../../assets';

import styles from './Sidebar.module.scss';
import classNames from 'classnames/bind';

const cx = classNames.bind(styles);
function Sidebar() {
  return (
    <div className={cx('sidebar-container')}>
      <img
        src={images.user_default}
        className={cx(['profile-img'])}
        alt='profile'
      />
      <div>
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

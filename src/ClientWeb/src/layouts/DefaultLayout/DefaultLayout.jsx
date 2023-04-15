import React from 'react';
import Sidebar from '../components/Sidebar/Sidebar';
import PlayerControl from 'components/Songs/SongPlayer/Controls';

function DefaultLayout({ children }) {
  return (
    <>
      <div className='h-[calc(100vh-var(--player-height))] grid grid-cols-12'>
        <div className='col-span-1 d-flex justify-content-center'>
          <Sidebar isFullHeight={false} />
        </div>
        <div className='col-span-11 bg-white h-[calc(100vh-var(--player-height))] border-b-2'>
          {children}
        </div>
      </div>

      <PlayerControl className='h-[var(--player-height)]' />
    </>
  );
}

export default DefaultLayout;

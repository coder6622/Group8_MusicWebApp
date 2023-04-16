import React from 'react';
import Sidebar from '../components/Sidebar/Sidebar';
import SongPlayer from 'components/Songs/SongPlayer';
import { useSelector } from 'react-redux';
import { isEmptyOrSpaces } from 'utils/Utils';

function DefaultLayout({ children }) {
  const songId = useSelector((state) => state.audioPlayer.songId);
  console.log(songId);
  console.log(isEmptyOrSpaces(songId));

  return (
    <>
      <div className='grid grid-cols-12'>
        <div className='col-span-1 d-flex justify-content-center'>
          <Sidebar isFullHeight={isEmptyOrSpaces(songId)} />
        </div>
        <div className='col-span-11 bg-white h-screen border-b-2'>
          {children}
        </div>
      </div>

      {isEmptyOrSpaces(songId) ? (
        ''
      ) : (
        <div className='h-[var(--player-height)] z-50 bg-black absolute bottom-0 left-0 right-0'>
          <SongPlayer />
        </div>
      )}
    </>
  );
}

export default DefaultLayout;

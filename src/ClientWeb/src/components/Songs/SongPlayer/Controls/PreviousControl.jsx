import PrevIcon from 'components/icons/PrevIcon';
import { IconColor, IconSize } from 'constants/icon';
import React from 'react';
import { useDispatch, useSelector } from 'react-redux';
import {
  changeIconPlay,
  setCurrnetIndexPlaylist,
  setSongId,
} from 'store/features/audioSlice';

export default function PreviousControl() {
  const dispatch = useDispatch();

  const { playlistSong, currentIndexPlaylist } = useSelector(
    (state) => state.audioPlayer,
  );

  const handlePreviousSong = () => {
    if (playlistSong !== undefined && playlistSong.length > 0) {
      let currentIndex;

      if (currentIndexPlaylist === 0) {
        currentIndex = 0;
      } else {
        currentIndex = currentIndexPlaylist - 1;
      }

      dispatch(setCurrnetIndexPlaylist(currentIndex));

      dispatch(setSongId(playlistSong[currentIndex].id));

      dispatch(changeIconPlay(true));
    }
  };

  return (
    <button
      className='btn-controls'
      onClick={handlePreviousSong}
      title='Previous Song'
    >
      <PrevIcon
        setColor={IconColor}
        setWidth={IconSize.small}
        setHeight={IconSize.small}
      />
    </button>
  );
}

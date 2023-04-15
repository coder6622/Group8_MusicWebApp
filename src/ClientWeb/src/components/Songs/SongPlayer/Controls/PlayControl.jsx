import React from 'react';
import { useDispatch, useSelector } from 'react-redux';

import PauseIcon from 'components/icons/PauseIcon';
import PlayIcon from 'components/icons/PlayIcon';

import { IconSize } from 'constants/icon';

import { changeIconPlay } from 'store/features/audioSlice';

function PlayControl({ audioRef }) {
  const dispatch = useDispatch();
  const isPlay = useSelector((state) => state.audioPlayer.isPlay);

  const handlePlaySong = () => {
    if (isPlay) {
      dispatch(changeIconPlay(false));
      if (audioRef) {
        audioRef.pause();
      }
    } else {
      dispatch(changeIconPlay(true));
      if (audioRef) {
        audioRef.play();
      }
    }
  };

  return (
    <button onClick={handlePlaySong}>
      {isPlay ? (
        <PlayIcon
          setColor='white'
          setWidth={IconSize.lg}
          setHeight={IconSize.lg}
        />
      ) : (
        <PauseIcon
          setColor='white'
          setWidth={IconSize.lg}
          setHeight={IconSize.lg}
        />
      )}
    </button>
  );
}

export default PlayControl;

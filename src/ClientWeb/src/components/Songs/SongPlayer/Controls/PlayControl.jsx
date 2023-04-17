import React from 'react';
import { useDispatch, useSelector } from 'react-redux';

import PauseIcon from 'components/icons/PauseIcon';
import PlayIcon from 'components/icons/PlayIcon';

import { IconColor, IconSize } from 'constants/icon';

import { changeIconPlay } from 'store/features/audioSlice';

function PlayControl({ songRef }) {
  const dispatch = useDispatch();
  const isPlay = useSelector((state) => state.audioPlayer.isPlay);

  const handlePlaySong = () => {
    if (isPlay) {
      dispatch(changeIconPlay(false));
      if (songRef) {
        console.log('pause');
        songRef.pause();
      }
    } else {
      dispatch(changeIconPlay(true));
      if (songRef) {
        console.log('play');
        songRef.play();
      }
    }
  };

  return (
    <button onClick={handlePlaySong}>
      {isPlay ? (
        <PauseIcon
          setColor={IconColor}
          setWidth={IconSize.lg}
          setHeight={IconSize.lg}
        />
      ) : (
        <PlayIcon
          setColor={IconColor}
          setWidth={IconSize.lg}
          setHeight={IconSize.lg}
        />
      )}
    </button>
  );
}

export default PlayControl;

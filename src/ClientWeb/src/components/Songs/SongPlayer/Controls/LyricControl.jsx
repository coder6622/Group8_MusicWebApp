import LyricIcon from 'components/icons/LyricIcon';
import { IconColor, IconSize } from 'constants/icon';
import React from 'react';

export default function LyricControl() {
  return (
    <button className='btn-controls'>
      <LyricIcon
        setColor={IconColor}
        setWidth={IconSize.small}
        setHeight={IconSize.small}
      />
    </button>
  );
}

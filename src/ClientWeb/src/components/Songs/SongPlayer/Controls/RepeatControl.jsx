import RepeatIcon from 'components/icons/RepeatIcon';
import { IconColor, IconSize } from 'constants/icon';
import React from 'react';

function RepeatControl() {
  return (
    <button
      className='btn-controls'
      title='Previous Song'
    >
      <RepeatIcon
        setColor={IconColor}
        setWidth={IconSize.small}
        setHeight={IconSize.small}
      />
    </button>
  );
}

export default RepeatControl;

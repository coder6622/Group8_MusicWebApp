import ShuffleIcon from 'components/icons/ShuffleIcon';
import { IconColor, IconSize } from 'constants/icon';
import React from 'react';

function ShuffleControl() {
  return (
    <button
      className='btn-controls'
      title='Previous Song'
    >
      <ShuffleIcon
        setColor={IconColor}
        setWidth={IconSize.small}
        setHeight={IconSize.small}
      />
    </button>
  );
}

export default ShuffleControl;

import React from 'react';
import styled from 'styled-components';
import TextBox from './TextBox';

const EditableText = styled.div`
  display: inline-block;
  &:hover {
    &:after {
      font-family: "Material Icons";
      content: "edit";
    }
  }
`;

class InlineEdit extends React.Component {
  state = {
    edit: false,
    value: this.props.text
  };

  handleBlur = _ => {
    this.setState({ edit: false });
  };

  handleClick = event => {
    event.stopPropagation();
    if (!this.state.edit) this.setState({ edit: true });
  };

  handleUpdate = _ => {
    this.setState({ edit: false });
    if (this.state.value.length > 0 && this.state.value != this.props.text) {
      this.props.onChange(this.state.value);
    }
    else this.setState({ value: this.props.text });
  };

  render() {
    const textStyle = { display: 'inline-block' };

    if (this.state.edit)
      return (
        <div>
          <TextBox
            id="EditField"
            ref={input => input && input.focus()}
            value={this.state.value}
            onBlur={this.handleBlur}
            onClick={this.handleClick}
            onUpdate={this.handleUpdate}
            onChange={value => this.setState({ value: value })}
          />
        </div>
      );

    return <EditableText onClick={this.handleClick}>{this.state.value}</EditableText>;
  }
}

export default InlineEdit;

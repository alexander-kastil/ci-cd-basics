import * as React from "react";
import styles from "./SpFxWp.module.scss";
import { ISpFxWpProps } from "./ISpFxWpProps";
import { escape } from "@microsoft/sp-lodash-subset";

export default class SpFxWp extends React.Component<ISpFxWpProps, {}> {
  public render(): React.ReactElement<ISpFxWpProps> {
    return (
      <div className={styles.spFxWp}>
        <div className={styles.container}>
          <div className={styles.row}>
            <div className={styles.column}>
              <span className={styles.title}>Welcome to SPFx and DevOps!</span>
              <p className={styles.subTitle}>
                Customize SharePoint experiences using Web Parts.
              </p>
              <p className={styles.description}>
                {escape(this.props.description)}
              </p>
              <a href="https://aka.ms/spfx" className={styles.button}>
                <span className={styles.label}>Learn more</span>
              </a>
            </div>
          </div>
        </div>
      </div>
    );
  }
}

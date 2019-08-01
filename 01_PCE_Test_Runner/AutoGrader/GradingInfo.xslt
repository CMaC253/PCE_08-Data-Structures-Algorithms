<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

	<!-- The exercise name to put at the top of the document -->
	<xsl:template name="LessonNumber">PCE 08</xsl:template>


  <!-- This is for Categories that have a name, but the name doesn't match anything.
			This should never happen 'in production', and will be flagged as an error 
			during the output phase -->
  <xsl:template match="Category[@name!='']" priority="-10">
    <xsl:call-template name="GenerateFailedTest">
      <xsl:with-param name="CategoryName">
        <xsl:value-of select="$Missing_Category"/>
      </xsl:with-param>
      <xsl:with-param name="NodeList" select="." />
      <xsl:with-param name="PointPenalty" select="-1" />
      <xsl:with-param name="Explanation">
        Unable to find a grading category for <xsl:value-of select="@name"/>
      </xsl:with-param>
    </xsl:call-template>
  </xsl:template>

	<xsl:template match="Category[@name='BST Print Recursive']">
		<xsl:call-template name="GenerateFailedTest">
			<xsl:with-param name="CategoryName">
				<xsl:value-of select="@name"/>
			</xsl:with-param>
			<xsl:with-param name="NodeList" select="." />
			<xsl:with-param name="PointPenalty" select="-3" />
			<xsl:with-param name="Explanation">There is a problem with your "Recursive Print" exercise</xsl:with-param>
		</xsl:call-template>
	</xsl:template>

	<xsl:template match="Category[@name='BST Find Recursive']">
		<xsl:call-template name="GenerateFailedTest">
			<xsl:with-param name="CategoryName">
				<xsl:value-of select="@name"/>
			</xsl:with-param>
			<xsl:with-param name="NodeList" select="." />
			<xsl:with-param name="PointPenalty" select="-3" />
			<xsl:with-param name="Explanation">There is a problem with your "Recursive Find" exercise</xsl:with-param>
		</xsl:call-template>
	</xsl:template>

	<xsl:template match="Category[@name='BST Add Recursive']">
		<xsl:call-template name="GenerateFailedTest">
			<xsl:with-param name="CategoryName">
				<xsl:value-of select="@name"/>
			</xsl:with-param>
			<xsl:with-param name="NodeList" select="." />
			<xsl:with-param name="PointPenalty" select="-3" />
			<xsl:with-param name="Explanation">There is a problem with your "Recursive Add" exercise</xsl:with-param>
		</xsl:call-template>
	</xsl:template>

	<!-- 
		The following are not graded (the grading is disabled via the Description on the TextFixture
	-->

	<xsl:template match="Category[@name='BST Print Iterative']">
		<xsl:call-template name="GenerateFailedTest">
			<xsl:with-param name="CategoryName">
				<xsl:value-of select="@name"/>
			</xsl:with-param>
			<xsl:with-param name="NodeList" select="." />
			<xsl:with-param name="PointPenalty" select="-2" />
			<xsl:with-param name="Explanation">There is a problem with your "Iterative Print" exercise</xsl:with-param>
		</xsl:call-template>
	</xsl:template>

	<xsl:template match="Category[@name='BST PrintBeneathNode']">
		<xsl:call-template name="GenerateFailedTest">
			<xsl:with-param name="CategoryName">
				<xsl:value-of select="@name"/>
			</xsl:with-param>
			<xsl:with-param name="NodeList" select="." />
			<xsl:with-param name="PointPenalty" select="-2" />
			<xsl:with-param name="Explanation">There is a problem with your "Print Beneath Node" exercise</xsl:with-param>
		</xsl:call-template>
	</xsl:template>


</xsl:stylesheet>

